using Domen;
using Kontroler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Obrada
    {
        private Socket klijentskiSoket;
        private readonly Server s;
        private NetworkStream stream;
        private BinaryFormatter formatter = new BinaryFormatter();

        public Obrada(Socket klijentskiSoket, Server s)
        {
            this.klijentskiSoket = klijentskiSoket;
            this.s = s;
            stream = new NetworkStream(klijentskiSoket);
        }

        public void ObradaZahteva()
        {
            bool kraj = false;
            while (!kraj)
            {
                try
                {
                    Zahtev zahtev = (Zahtev)formatter.Deserialize(stream);
                    Odgovor o = IzvrsiZahtev(zahtev);
                    formatter.Serialize(stream, o);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($">>> {ex.Message}");
                    kraj = true;
                }
            }

        }

        public Odgovor IzvrsiZahtev(Zahtev zahtev)
        {
            Odgovor odgovor = new Odgovor();
            try
            {
                switch (zahtev.Operacija)
                {
                    case Operacija.Login:
                        Korisnik k = (Korisnik)zahtev.Objekat;
                        //metoda prijavi se baca exception ukoliko ne pronadje korisnika
                        Korisnik pronadjeniKorisnik = Kontroler.Kontroler.Instance.Prijava(k.KorisnickoIme, k.Password);
                        odgovor.Poruka = "Sistem je uspesno pronasao korisnika!";
                        odgovor.Objekat = pronadjeniKorisnik;
                        s.Klijenti.Add(pronadjeniKorisnik);
                        s.OnPrijavljen();
                        break;
                    case Operacija.VratiSveProizvode:
                        odgovor.Objekat = Kontroler.Kontroler.Instance.VratiSveProizvode();
                        odgovor.Poruka = "Sistem je uspesno pronasao proizvode!";
                        break;
                    case Operacija.PretraziProizvode:
                        odgovor.Objekat = Kontroler.Kontroler.Instance.PretraziProizvode(zahtev.Objekat.ToString());
                        odgovor.Poruka = "Sistem je uspesno pretrazio proizvode!";
                        break;
                }
            }
            catch (Exception e)
            {
                odgovor.Signal = Signal.Error;
                odgovor.Poruka = e.Message;
            }
            return odgovor;
        }
    }
}

