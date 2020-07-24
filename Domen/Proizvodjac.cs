using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Proizvodjac
    {
        public int ID { get; set; }
        public string Naziv { get; set; }

        public override string ToString()
        {
            return Naziv;
        }

        public override bool Equals(object obj)
        {
            if(obj is Proizvodjac p)
            {
                return p.ID == this.ID;
            }
            return false;
        }
    }
}
