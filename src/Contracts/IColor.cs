﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnaya.Samples
{
    public interface IColor
    {
        void Write(ConsoleColor c, Action action);
    }
}
