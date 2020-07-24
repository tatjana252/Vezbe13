using Domen;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerBazePodataka
{
    public class Broker
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        public Broker()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
        }

        public int VratiNovId(IDomenskiObjekat objekat)
        {
            try
            {
                string kurs = ConfigurationManager.AppSettings["srednji_kurs_nbs"];
                double k = Double.Parse(kurs);

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"SELECT MAX({objekat.ColumnId}) FROM {objekat.Table}";
                object rez = command.ExecuteScalar();
                if (rez is DBNull)
                {
                    return 1;
                }
                int maxid = (int)rez;
                return maxid + 1;
            }
            finally
            {
                connection.Close();
            }
        }

        public void OtvoriKonekciju()
        {
            connection.Open();
        }

        public void ZatvoriKonekciju()
        {
            connection.Close();
        }

        public void PokreniTransakciju()
        {
            transaction = connection.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public List<Proizvodjac> VratiSveProizvodjace()
        {
            List<Proizvodjac> proizvodjaci = new List<Proizvodjac>();
            SqlDataReader reader = null;
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Proizvodjac"; // za select
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Proizvodjac p = new Proizvodjac();
                    p.ID = (int)reader["Id"];
                    p.Naziv = (string)reader["Naziv"];
                    proizvodjaci.Add(p);
                }
            }
            catch (Exception e)
            {
                //throw;
                throw new Exception("Greska pri radu sa bazom!");
            }
            finally
            {
                if (reader != null) reader.Close();
                connection.Close();
            }

            return proizvodjaci;
        }

        public List<Dobavljac> VratiSveDobavljace()
        {
            List<Dobavljac> dobavljaci = new List<Dobavljac>();
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = "select * from Dobavljac";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Dobavljac p = new Dobavljac
                {
                    Id = reader.GetInt32(0),
                    Naziv = reader.GetString(1),
                };
                dobavljaci.Add(p);
            }
            reader.Close();
            return dobavljaci;
        }

        public int SacuvajDobavljanje(Dobavljanje d)
        {
            SqlCommand command = new SqlCommand("Insert into Dobavljanje values(@Dobavljac, @Proizvod, @Datum, @Opis)");
            command.Parameters.AddWithValue("@Dobavljac", d.Dobavljac);
            command.Parameters.AddWithValue("@Proizvod", d.Proizvod);
            command.Parameters.AddWithValue("@Datum", d.Datum);
            command.Parameters.AddWithValue("@Opis", d.Opis);
            return command.ExecuteNonQuery();
        }

        public List<Proizvod> VratiSveProizvode()
        {
            try
            {
                List<Proizvod> proizvodi = new List<Proizvod>();
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select p.Id, p.Naziv, Cena, Proizvodjac, pr.Naziv as naziv_proizvodjaca from Proizvod p join Proizvodjac pr on (p.Proizvodjac=pr.Id)";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Proizvod p = new Proizvod
                    {
                        ID = reader.GetInt32(0),
                        Naziv = reader.GetString(1),
                        Cena = reader.GetDouble(2),
                        Proizvodjac = new Proizvodjac
                        {
                            ID = reader.GetInt32(3),
                            Naziv = reader.GetString(4) //Naziv = reader["naziv_proizvodjaca"]
                            //Naziv = reader["pr.Naziv"] NE MOZE!!!
                        }
                    };
                    proizvodi.Add(p);
                }
                reader.Close();
                return proizvodi;
            }
            finally
            {
                connection.Close();
            }
        }

        public void SacuvajStavkuRacuna(StavkaRacuna s)
        {

        }

        public void SacuvajRacun(Racun racun)
        {
            try
            {
                SqlCommand commandRacun = new SqlCommand("insert into Racun output inserted.Id values (@Datum, @Korisnik)", connection, transaction);
                commandRacun.Parameters.AddWithValue("@Datum", racun.Datum);
                commandRacun.Parameters.AddWithValue("@Korisnik", $"{racun.Korisnik.Ime} {racun.Korisnik.Prezime}");
                racun.Id = (int)commandRacun.ExecuteScalar();
                //racun.Id = VratiNovRacunId();
                foreach (StavkaRacuna s in racun.StavkeRacuna)
                {
                    SqlCommand command = new SqlCommand("insert into StavkaRacuna values (@RB, @Racun, @Kolicina, @UkupanIznos, @Proizvod)", connection, transaction);
                    command.Parameters.AddWithValue("@RB", s.RBr);
                    command.Parameters.AddWithValue(@"Racun", racun.Id);
                    command.Parameters.AddWithValue("@Kolicina", s.Kolicina);
                    command.Parameters.AddWithValue("@UkupanIznos", s.UkupanIznos);
                    command.Parameters.AddWithValue("@Proizvod", s.Proizvod.ID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(">>>" + e.Message);
                throw;
            }
        }

        public int VratiNovRacunId()
        {
            try
            {
                SqlCommand command = new SqlCommand("", connection, transaction);
                command.CommandText = "SELECT MAX(Id) FROM Racun";
                object rez = command.ExecuteScalar();
                return (int)rez;
            }
            catch (Exception)
            {
                // return 1;
                throw;
            }
        }

        public bool SacuvajProizvod(Proizvod p)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                //string cena = p.Cena.ToString().Replace(",", ".");
                command.CommandText = $"INSERT INTO Proizvod VALUES (@ProizvodId, @Naziv, @Cena, @Proizvodjac)";
                command.Parameters.AddWithValue("@ProizvodId", p.ID);
                command.Parameters.AddWithValue("@Naziv", p.Naziv);
                command.Parameters.AddWithValue("@Cena", p.Cena);
                command.Parameters.AddWithValue("@Proizvodjac", p.Proizvodjac.ID);
                int rez = command.ExecuteNonQuery(); //za insert, update, delete
                //if (rez == 1)
                //{
                //    return true;
                //}
                //return false;
                return rez == 1;
            }
            finally
            {
                connection.Close();
            }
        }
        public int VratiNovIdProizvod()
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                // connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "SELECT MAX(Id) FROM Proizvod";
                object rez = command.ExecuteScalar();
                if (rez is DBNull)
                {
                    return 1;
                }
                int maxid = (int)rez;
                return maxid + 1;
            }
            catch (Exception)
            {
                // return 1;
                throw;
            }
            finally
            {
                connection.Close();
            }
        }


        public List<IDomenskiObjekat> Search(string criteria, IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand();
            command.Transaction = transaction;
            command.Connection = connection;
            command.CommandText = $"select * from {objekat.Table} {objekat.Join} {objekat.SearchWhere(criteria)}";
            SqlDataReader reader = command.ExecuteReader();
            return objekat.GetReaderResult(reader);
        }

        public int Insert(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand();
            command.Transaction = transaction;
            command.Connection = connection;
            command.CommandText = $"insert into {objekat.Table} values({objekat.InsertValues})";
            return command.ExecuteNonQuery();
        }
    }



}

