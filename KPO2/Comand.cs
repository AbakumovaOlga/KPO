﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPO2
{
    abstract class Command
    {
        public abstract void Execute(List<Osob> popul, List<Food> foods);
      //  public abstract void Undo();
    }
}
