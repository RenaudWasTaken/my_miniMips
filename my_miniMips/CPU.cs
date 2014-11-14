﻿using System;
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

        private readonly Environment _env;
        private ALU _alu;

        public CPU(Environment env)
        {
            GReg = new int[32];
            _env = env;
            GReg[29] = env.StackBase;
            _alu = new ALU(this);
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

        public int fetch_instruction()
        {
            return this._env.RAM[this.PC];
        }        

        public void run()
        {
            int instruction, rs, rt, rd, shamt, funct, opcode, imm, jmp;
            int rs_val, rt_val, rd_val;

            Decoder d = new Decoder();


            while (true)
            {
                instruction = this.fetch_instruction();
                d.decode_instruction(instruction, out opcode,
                                     out rs, out rt, out rd, out shamt, out funct, out imm, out jmp);
                rs_val = this.GReg[rs];
                rt_val = this.GReg[rt];
                rd_val = this.GReg[rd];

                this.PC += 4;
                if (PC >= _env.StackLimit)
                    break;
            }
        }
    }
}
