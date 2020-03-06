using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPO2
{
    class ComandPrisp : Command
    {
        Service receiver;
        public ComandPrisp(Service r)
        {
            receiver = r;
        }
        public override void Execute(List<Osob> popul, List<Food> foods )
        {
            receiver.Operation(popul, foods);
        }


    }
}
