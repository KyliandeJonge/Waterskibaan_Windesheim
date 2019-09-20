using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan.classes
{
    public class Lijn
    {
        private int positieOpKabel = 0;

        public int PositieOpKabel {
            get
            {
                return positieOpKabel;
            }
            set
            {
                this.positieOpKabel = value;
            }
        }
       
        public Lijn()
        {
           
        }

      
    }
}
