using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Proizvod : IDomenskiObjekat
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        //decimal
        public double Cena { get; set; } //u SQL Serveru float!

        //[Browsable(false)]
        public Proizvodjac Proizvodjac { get; set; }
        public Proizvod Vrednost { get { return this; } }

        //[DisplayName("Proizvodjac")]\
        //public string Naziv_Proizvodjaca { get { return Proizvodjac.Naziv; } }

        public override string ToString()
        {
            return Naziv;
        }

        public override bool Equals(object obj)
        {
            if (obj is Proizvod p)
            {
                return p.ID == ID;
            }
            return false;
        }

        public Proizvod Self { get { return this; } }

        public string Table => "Proizvod proizvod";

        public string InsertValues => $"{ID}, '{Naziv}', {Cena}, {Proizvodjac.ID}";

        public string UpdateValues => $"Id = {ID}, Naziv = '{Naziv}', Cena={Cena}, Proizvodjac ={Proizvodjac.ID}";

        public string Join => $"join Proizvodjac proizvodjac on (proizvod.Proizvodjac=proizvodjac.Id)";

        public string SearchWhere(string criteria)
        {
            return $"where proizvod.Naziv like '%{criteria}%' or proizvodjac.Naziv like '%{criteria}%'";
        }

        public List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();
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
                        Naziv = reader.GetString(5)
                    }
                };
                lista.Add(p);
            }
            return lista;
        }

        public string SearchId => $"where Id = {ID}";

        public object ColumnId => "Id";
    }
}
