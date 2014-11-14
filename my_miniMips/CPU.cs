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
        }

        public int GetSP()
        {
            return GReg[29];
        }

        public void MoveSP(int offset)
        {
            GReg[29] += offset;
        }

        public int fetch_instruction()
        {
            return this._env.RAM[this.PC];
        }        

        public void run()
        {
            int instruction, rs, rt, rd, shamt, funct, opcode, imm, jmp;

            instruction = this.fetch_instruction();
            new Decoder().decode_instruction(instruction, out opcode,
                                             out rs, out rt, out rd, out shamt, out funct, out imm, out jmp);

            this.PC += 4;
        }
    }
}
