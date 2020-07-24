using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace Storage
{
    public class StorageKorisnik
    {
        private List<Korisnik> korisnici;

        public StorageKorisnik()
        {
            korisnici = new List<Korisnik>() {
                new Korisnik {
                Ime = "Mika",
                Prezime = "Peric",
                Email = "mika@gmail.com",
                Pol = Pol.muski,
                KorisnickoIme= "mika",
                Password = "mika"
            } };

            Korisnik k = new Korisnik();
            k.Ime = "Pera";
            k.Prezime = "Peric";
            k.Pol = Pol.muski;
            k.Email = "pera@gmail.com";
            k.KorisnickoIme = "pera";
            k.Password = "pera";

            Korisnik k1 = new Korisnik()
            {
                Ime = "Zika",
                Prezime = "Peric",
                Email = "zika@gmail.com",
                Pol = Pol.muski,
                KorisnickoIme = "zika",
                Password = "zika"
            };
            korisnici.Add(k);
            korisnici.Add(k1);
        }

        public List<Korisnik> VratiSve()
        {
            return korisnici;
        }
    }
}
