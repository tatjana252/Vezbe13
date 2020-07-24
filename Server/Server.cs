using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        private Socket osluskujuciSoket;

        public List<Korisnik> Klijenti { get; internal set; } = new List<Korisnik>();

        public event PrijavljenNovEventHandler PrijavljenNov;

        public delegate void PrijavljenNovEventHandler();

        public bool PokreniServer()
        {
            try
            {
                osluskujuciSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                osluskujuciSoket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9090));
                osluskujuciSoket.Listen(5);

                return true;
            }
            catch (SocketException)
            {
                return false;
            }
        }

        public void Osluskuj()
        {
            bool kraj = false;
            while (!kraj)
            {
                Socket klijentskiSoket = osluskujuciSoket.Accept();
                Obrada obrada = new Obrada(klijentskiSoket, this);
                Thread nitKlijenta = new Thread(obrada.ObradaZahteva);
                nitKlijenta.Start();
            }
        }

        internal void OnPrijavljen()
        {
            PrijavljenNov?.Invoke();
        }
    }
}
