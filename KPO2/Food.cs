using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPO2
{
   public  class Food : Essence
    {
        public string Name;
        public double Prot;
        public double Fat;
        public double Car;
        public double Kkal;
        public double Price;
     //   public double Count = 0;
        public Food(string name, double prot, double fat, double car, double kkal, double price)
        {
            Name = name;
            Prot = prot;
            Fat = fat;
            Car = car;
            Kkal = kkal;
            Price = price;
        }
    }
}
