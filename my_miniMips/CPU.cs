using System;
using System.IO;

namespace my_miniMips
{
    class CPU
    {
        public static int TMP = 8;
        public static int VAL = 2;
        public static int end = 0; 
        public int[] GReg { get; private set; }
        public int PC { get; set; }
        public int HI { get; set; }
        public int LO { get; set; }

        private readonly Environment _env;
        private ALU _alu;
		private Decoder _decoder;

        public CPU(Environment env)
        {
            GReg = new int[32];
            _env = env;
            GReg[29] = env.StackBase;
            _alu = new ALU(this);
			_decoder = new Decoder ();
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
            byte[] ins = new byte[4];
            for (int i = 0; i < 4; i++)
                ins[i] = _env.RAM[PC + i];

            return BitConverter.ToInt32(ins, 0);
        }        

        public void run()
        {
            while (end == 0)
            {
                int instruction = this.fetch_instruction();
				Instruction i = _decoder.decode_instruction(instruction);

                this.PC += 4;
				_alu.exec(i);

                if (PC >= _env.StackLimit)
                    break;
            }
        }
    }
}
