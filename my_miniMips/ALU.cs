using System;
using System.Collections.Generic;

namespace my_miniMips
{
    class ALU
    {
        private CPU _cpu;
        delegate void operation(Instruction i);
        private Dictionary<int, operation> operations = new Dictionary<int, operation>();

        public ALU(CPU cpu)
        {
            _cpu = cpu;
            operations.Add(32, Add);
            operations.Add(33, Addu);
            operations.Add(9, Addiu);
            operations.Add(8, Addi);
        }
        
        public int exec(Instruction i)
        {

            return 0;
        }

        public void Add(Instruction i)
        {
        }

        public void Addi(Instruction i)
        {
            
        }

        public void Addiu(Instruction i)
        {
            
        }

        public void Addu(Instruction i)
        { }
    }
}
