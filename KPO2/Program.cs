using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPO2
{
    class Program
    {
       


        static void Main(string[] args)
        {

            Singleton comp=Singleton.getExecutor();
           
            Console.WriteLine("Hello World!");

            comp.Init();

            comp.generatePopul(10);

            comp.checkFoods();
            Service receiver = new Service();
            ComandPrisp command = new ComandPrisp(receiver);
            comp.SetCommand(command);
            comp.launch(10);

            comp.reslt();


            Console.ReadLine();
        }
    }
}
