using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Korisnik
    {
        private string ime;
        public string Ime { get => ime; set => ime = value; }

        private string prezime;
        public string Prezime
        {
            get
            {
                return prezime;
            }
            set
            {
                prezime = value;
            }
        }

        public string Email { get; set; }
        public string KorisnickoIme { get; set; }
        public string Password { get; set; }
        public Pol Pol { get; set; }
    }

    public enum Pol
    {
        muski,
        zenski
    }
}
