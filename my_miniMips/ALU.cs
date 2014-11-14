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
            operations.Add(32, this.Add);
            operations.Add(33, this.Addu);
            operations.Add(9 , this.Addiu);
            operations.Add(8 , this.Addi);
            operations.Add(12, this.syscall);
        }
        
        public void exec(Instruction i)
        {
            if (i.Opcode == 0)
                this.operations[i.Funct](i);
            else
                this.operations[i.Opcode](i);
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

        public void Sub(Instruction i)
        {
            _cpu.GReg[i.Rd] = _cpu.GReg[i.Rs] - _cpu.GReg[i.Rt];
        }

        public void Subu(Instruction i)
        {
            _cpu.GReg[i.Rd] = _cpu.GReg[i.Rs] - _cpu.GReg[i.Rt];
        }

        public void Beq(Instruction i)
        {
            if (_cpu.GReg[i.Rs] == _cpu.GReg[i.Rt])
                _cpu.PC += 4*i.Imm;
        }

        public void jump(Instruction i)
        {
            int addr = (i.Jmp & 0x03FFFFFF) << 2;
            int pc = this._cpu.PC & unchecked((int)0xF0000000);

            addr = addr | pc;
            this._cpu.PC = addr;
        }

        public void syscall(Instruction i)
        {
            if (this._cpu.GReg[CPU.VAL] == 1)
                Console.WriteLine(this._cpu.GReg[CPU.TMP]);
            else if (this._cpu.GReg[CPU.VAL] == 10)
                CPU.end = 1;
        }
    }
}
