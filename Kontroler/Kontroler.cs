using BrokerBazePodataka;
using Domen;
using SistemskeOperacije;
using Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontroler
{
    public class Kontroler
    {
        private Broker broker = new Broker();
        private static Kontroler _instance;
        public static Kontroler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Kontroler();
                }
                return _instance;
            }
        }
        private Kontroler()
        {
        }

        public Korisnik Prijava(string korIme, string pass)
        {
            StorageKorisnik storageKorisnik = new StorageKorisnik();
            List<Korisnik> korisnici = storageKorisnik.VratiSve();
            foreach (Korisnik k in korisnici)
            {
                if (k.KorisnickoIme == korIme && k.Password == pass)
                {
                    return k;
                }
            }
            throw new Exception("Korisnik nije pronadjen!");
        }

        public List<Dobavljac> VratiSveDobavljace()
        {
            broker.OtvoriKonekciju();
            List<Dobavljac> dobavljaci = broker.VratiSveDobavljace();
            broker.ZatvoriKonekciju();
            return dobavljaci;
        }

        public List<Proizvod> VratiSveProizvode()
        {
            return broker.VratiSveProizvode();
        }

        public List<Proizvodjac> VratiSveProizvodjace()
        {
            return broker.VratiSveProizvodjace();
        }

        public Proizvod SacuvajProizvod(Proizvod p)
        {
            //p.ID = broker.VratiNovIdProizvod();
            //bool uspesno = broker.SacuvajProizvod(p);
            //if (uspesno)
            //{
            //    return p;
            //}
            //else
            //{
            //    return null;
            //}
            OpstaSistemskaOperacija sistemskaOperacija = new SacuvajProizvodSO();
            sistemskaOperacija.Izvrsi(p);
            return ((SacuvajProizvodSO)sistemskaOperacija).Proizvod;
        }

        public List<Proizvod> PretraziProizvode(string criteria)
        {
            try
            {
                broker.OtvoriKonekciju();
                return broker.Search(criteria, new Proizvod()).OfType<Proizvod>().ToList();
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }

        public bool SacuvajRacun(Racun racun)
        {

            try
            {
                broker.OtvoriKonekciju();
                broker.PokreniTransakciju();
                broker.SacuvajRacun(racun);

                broker.Commit();
                return true;

            }
            catch (Exception)
            {

                broker.Rollback();
                return false;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }

        }

        public bool SacuvajSvaDobavljanja(BindingList<Dobavljanje> listaDobavljanja)
        {
            try
            {
                broker.OtvoriKonekciju();
                foreach (Dobavljanje d in listaDobavljanja)
                {
                    if (broker.SacuvajDobavljanje(d) == 0)
                    {
                        throw new Exception();
                    }
                }
                broker.Commit();
                return true;
            }
            catch
            {
                broker.Rollback();
                return false;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }
    }
}
