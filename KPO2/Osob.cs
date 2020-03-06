using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPO2
{
    public class Osob : Essence
    {
        public int[] hrom;

     //   public double fPrisp;

        public int start;
        public int finish;

        public Osob(int[] hrom)
        {
            this.hrom = hrom;
        }
    }
}
