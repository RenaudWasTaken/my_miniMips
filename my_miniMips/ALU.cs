using System;

﻿namespace my_miniMips
{
    class ALU
    {
        private CPU _cpu;

        public ALU(CPU cpu)
        {
            _cpu = cpu;
        }

        public void Add(Instruction i)
        {
            _cpu.GReg[i.Rd] = _cpu.GReg[i.Rs] + _cpu.GReg[i.Rt];
        }

        public void Addi(Instruction i)
        {
            _cpu.GReg[i.Rt] = _cpu.GReg[i.Rs] + i.Imm;
        }

        public void Addiu(Instruction i)
        {
            _cpu.GReg[i.Rt] = (int) (_cpu.GReg[i.Rs] + (UInt32)i.Imm);
        }

        public void Addu(Instruction i)
        {
            _cpu.GReg[i.Rd] = (int) (_cpu.GReg[i.Rs] + (UInt32)_cpu.GReg[i.Rt]);
        }
    }
}
