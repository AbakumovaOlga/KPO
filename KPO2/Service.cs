using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPO2
{
    class Service
    {
        double nProt = 34;
        double nFat = 25;
        double nCar = 60;
        double nKkal = 600;
        public void Operation(List<Osob> popul, List<Food> foods)
        {
           
            foreach (var os in popul)
            {
                double sumCar = 0;
                double sumFat = 0;
                double sumProt = 0;
                double sumKkal = 0;
                for (int i = 0; i < foods.Count; i++)
                {
                    if (os.hrom[i] == 1)
                    {
                        sumCar += foods[i].Car;
                        sumFat += foods[i].Fat;
                        sumProt += foods[i].Prot;
                        sumKkal += foods[i].Kkal;
                    }

                }
                //   double s1 = Math.Sqrt(Math.Abs(nKkal - sumKkal));
                os.mainHar = Math.Sqrt(Math.Abs(nKkal - sumKkal)) + Math.Sqrt(Math.Abs(nFat - sumFat)) + Math.Sqrt(Math.Abs(nProt - sumProt)) + Math.Sqrt(Math.Abs(nCar - sumCar));


                //    fPrisp[j] = Math.Sqrt(nKkal - foods[i].Kkal)+ Math.Sqrt(nFat - foods[i].Fat)+ Math.Sqrt(nProt - foods[i].Prot)+ Math.Sqrt(nCar - foods[i].Car);

            }
        }
    }
}
