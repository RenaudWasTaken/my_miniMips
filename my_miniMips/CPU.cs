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

        private Environment _env;

        public CPU(Environment env)
        {
            GReg = new int[32];
            _env = env;
            GReg[29] = env.StackBase;
        }

        public int GetSP()
        {
            return GReg[29];
        }

        public void AddSP(int size)
        {
            if (GetSP() - size <= _env.StackLimit)
                throw new Exception("Stack overflow");
            GReg[29] -= size;
        }

        public void SubSP(int size)
        {
            if (GetSP() + size > _env.StackBase)
                throw  new Exception("Stack underflow");

            GReg[29] += size;
        }
    }
}
