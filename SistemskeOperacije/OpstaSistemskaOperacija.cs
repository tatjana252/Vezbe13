using BrokerBazePodataka;
using Domen;
using System;

namespace SistemskeOperacije
{
    public abstract class OpstaSistemskaOperacija
    {
        protected Broker broker = new Broker();
        protected abstract void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat);
        protected abstract void Validacija(IDomenskiObjekat objekat);
        public void Izvrsi(IDomenskiObjekat objekat)
        {
            try
            {
                Validacija(objekat);
                broker.OtvoriKonekciju();
                broker.PokreniTransakciju();
                IzvrsiKonkretnuOperaciju(objekat);
                broker.Commit();
            }
            catch (Exception)
            {
                broker.Rollback();
                throw;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }

    }
}
