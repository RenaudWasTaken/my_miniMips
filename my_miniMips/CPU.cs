using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_miniMips
{
    class CPU
    {
        public int[] GReg { get; private set; }
        public int PC { get; set; }
        public int HI { get; set; }
        public int LO { get; set; }

        public CPU()
        {
            GReg = new int[32];
        }

        public int GetSP()
        {
            return GReg[29];
        }
    }
}
