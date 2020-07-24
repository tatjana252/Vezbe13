using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Dobavljac
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public Dobavljac Self
        {
            get
            {
                return this;
            }
        }

        public override string ToString()
        {
            return Naziv;
        }

        public override bool Equals(object obj)
        {
            if(obj is Dobavljac d)
            {
                return d.Id == Id;
            }
            return false;
        }
    }
}
