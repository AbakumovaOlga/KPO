using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPO2
{
    class Singleton
    {
        private static Singleton executor;

        Random rand;
        public List<Food> foods;

        public List<Osob> popul;
        public List<Osob> childs;

        //   public  double[] fPrisp;

        double nProt;
        double nFat;

        internal void countOfFood()
        {
            for (int i = 0; i < foods.Count; i++)
            {
                foreach (var os in popul)
                {
                    if (os.hrom[i] == 1)
                    {
                        foods[i].mainHar++;
                    }
                }
            }
        }

        internal void reslt()
        {
            List<Osob> result1 = popul.OrderBy(u => u.mainHar).ToList();
            popul.Clear();

            foreach (var res in result1)
            {
                popul.Add(res);
            }
            int index = 0;

            double summaIndex = 0;
            for (int j = 0; j < foods.Count; j++)
            {
                if (popul[index].hrom[j] == 1)
                {
                    summaIndex += foods[j].Price;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                double summa = 0;
                for (int j = 0; j < foods.Count; j++)
                {
                    if (popul[i].hrom[j] == 1)
                    {
                        summa += foods[j].Price;
                    }
                }
                if (summa < summaIndex)
                {
                    index = i;
                    summaIndex = summa;
                }
            }

            for (int i = 0; i < foods.Count; i++)
            {
                if (popul[index].hrom[i] == 1)
                {

                    Console.WriteLine(foods[i].Name + " ");
                }



            }
            Console.WriteLine("\n" + summaIndex);
        }

        Command command;
        public void SetCommand(Command c)
        {
            command = c;
        }
        public void Run()
        {
            if (popul.Count == 0) return;
            command.Execute(popul, foods);
        }

        internal void launch(int countAge)
        {
            for (int z = 0; z < countAge; z++)
            {
                Run();
                minFprisp(popul);

                ruletka();

                mutat();

                Run();
                minFprisp(popul);
                Console.WriteLine();
            }
        }

        private void mutat()
        {
            foreach (Osob os in popul)
            {
                if (rand.Next(10) == 1)
                {
                    int mest = rand.Next(foods.Count);
                    if (os.hrom[mest] == 1)
                    {
                        os.hrom[mest] = 0;

                    }
                    else
                    {
                        os.hrom[mest] = 1;
                    }

                }
            }

            if (popul.Count == 0) return;


           
        }

        private void ruletka()
        {
            List<Osob> result = popul.OrderBy(u => u.mainHar).ToList();
            popul.Clear();
            double sumPrisp = 0;
            foreach (var res in result)
            {
                popul.Add(res);
                sumPrisp += res.mainHar;
            }

            int st = 0;
            foreach (var osob in popul)
            {
                osob.start = st;
                osob.finish = osob.start + (int)(sumPrisp / osob.mainHar);
                st += (int)(sumPrisp / osob.mainHar);
            }

            int skr = rand.Next(foods.Count);
            for (int p = 0; p < 5; p++)
            {
                int f = rand.Next(st);
                var first = popul.FirstOrDefault(u => u.start <= f & u.finish > f);
                int s = rand.Next(st);
                var second = popul.FirstOrDefault(u => u.start <= s & u.finish > s);


                int[] par1 = first.hrom;
                int[] par2 = second.hrom;


                int[] hrom1 = new int[foods.Count];
                int[] hrom2 = new int[foods.Count];
                for (int j = 0; j < foods.Count; j++)
                {
                    if (j < skr)
                    {
                        hrom1[j] = par1[j];
                        hrom2[j] = par2[j];
                    }
                    else
                    {
                        hrom1[j] = par2[j];
                        hrom2[j] = par1[j];

                    }


                }
                Osob osob = new Osob(hrom1);
                childs.Add(osob);
                Osob osob1 = new Osob(hrom2);
                childs.Add(osob1);

            }


            popul.Clear();
            foreach (Osob child in childs)
            {
                popul.Add(child);
            }

            childs.Clear();
        }

        internal void checkFoods()
        {
            countOfFood();
            foreach (var food in foods)
            {
                if (food.mainHar == 0)
                {
                    int[] hrom = new int[foods.Count];
                    for (int j = 0; j < foods.Count; j++)
                    {
                        hrom[j] = rand.Next(0, 2);
                    }
                    hrom[foods.IndexOf(food)] = 1;
                    Osob osob = new Osob(hrom);

                    popul.Add(osob);
                }
            }
        }

        double nCar;

        internal void generatePopul(int countOsob)
        {
            for (int i = 0; i < countOsob; i++)
            {

                int[] hrom = new int[foods.Count];
                for (int j = 0; j < foods.Count; j++)
                {
                    hrom[j] = rand.Next(0, 2);
                }



                int n = 0;
                for (int j = 0; j < foods.Count; j++)
                {
                    if (hrom[j] == 0)
                    {
                        n++;
                    }
                }
                if (n == foods.Count)
                {
                    i--;
                }
                else
                {

                    Osob osob = new Osob(hrom);

                    popul.Add(osob);
                }
            }
        }

        double nKkal;

        double razProt;
        double razFat;
        double razCar;
        double razKkal;

        private Singleton()
        { }

        private static object syncRoot = new Object();

        public static Singleton getExecutor()
        {
            if (executor == null)
            {
                lock (syncRoot)
                {
                    if (executor == null)
                    {
                        executor = new Singleton();
                    }
                }
               
            }
            return executor;
        }

        internal void Init()
        {
            rand = new Random();
            foods = new List<Food>();
            foods.Add(new Food("Apple", 0.4, 0.4, 9.8, 47, 15));
            foods.Add(new Food("Egg", 6.3, 5.31, 0.56, 78, 3));
            foods.Add(new Food("Oatmeal", 6.5, 3.1, 33, 178, 20));
            foods.Add(new Food("Juice", 0, 0, 12, 48, 25));
            foods.Add(new Food("Yogurt", 4, 2.7, 6.8, 75, 15));
            foods.Add(new Food("Banana", 16, 40, 0, 420, 10));
            foods.Add(new Food("Bread", 8.5, 3.3, 48.3, 250, 20));

           

            razProt = 10;
            razFat = 5;
            razCar = 10;
            razKkal = 40;


            popul = new List<Osob>();
            childs = new List<Osob>();
        }

        private void minFprisp(List<Osob> popul)
        {
            int indexMinPasp = 0;
            double minFPrisp = popul[indexMinPasp].mainHar;

            for (int i = 0; i < popul.Count; i++)
            {
                if (popul[i].mainHar < minFPrisp)
                {
                    minFPrisp = popul[i].mainHar;
                    indexMinPasp = i;
                }
            }
         //   Console.WriteLine(indexMinPasp + "     " + minFPrisp);
          //  Console.WriteLine();

        }
    }
}
