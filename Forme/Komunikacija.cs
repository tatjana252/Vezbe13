using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace Forme
{
    public class Komunikacija
    {
        private static Komunikacija instance;
        private Socket klijentskiSocket;
        private NetworkStream stream;
        private BinaryFormatter formatter = new BinaryFormatter();

        internal void PosaljiZahtev(Zahtev z)
        {
            formatter.Serialize(stream, z);
        }

        internal Odgovor ProcitajOdgovor()
        {
            try
            {
                return (Odgovor)formatter.Deserialize(stream);
            }
            catch (Exception e)
            {
                Debug.WriteLine(">>>" + e.Message);
                return null;
            }
        }

        private Komunikacija()
        {
            //klijentskiSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public static Komunikacija Instance
        {
            get
            {
                if (instance == null) instance = new Komunikacija();
                return instance;
            }
        }

        internal Korisnik Prijava(string korIme, string pass)
        {
            Korisnik k = new Korisnik { KorisnickoIme = korIme, Password = pass };
            Zahtev z = new Zahtev { Operacija = Operacija.Login, Objekat = k };
            formatter.Serialize(stream, z);
            Odgovor odg = ProcitajOdgovor();
            return (Korisnik)odg.Objekat;
        }

        public List<Proizvod> VratiSveProizvode()
        {
            Zahtev z = new Zahtev { Operacija = Operacija.VratiSveProizvode };
            formatter.Serialize(stream, z);
            
            Odgovor odg = (Odgovor)formatter.Deserialize(stream);
            if (odg.Signal == Signal.Ok)
            {
                return (List<Proizvod>)odg.Objekat;
            }
            else
            {
                throw new Exception(odg.Poruka);
            }
        }

        public bool PoveziSe()
        {
            try
            {
                if (klijentskiSocket == null || !klijentskiSocket.Connected)
                {
                    klijentskiSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    klijentskiSocket.Connect("localhost", 9090);
                    stream = new NetworkStream(klijentskiSocket);
                }
                return true;
            }
            catch (SocketException)
            {
                return false;
            }
        }
    }
}
