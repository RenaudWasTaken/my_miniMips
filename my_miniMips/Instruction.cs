namespace my_miniMips
{
    class Instruction
    {
        public int Ins { get; set; }
        public int Rs { get; set; }
        public int Rt { get; set; }
        public int Rd { get; set; }
        public int Shamt { get; set; }
        public int Funct { get; set; }
        public int Opcode { get; set; }
        public int Imm { get; set; }
        public int Jmp { get; set; }

        public Instruction(int ins, int opcode, int rs, int rt, int rd,
                                        int shamt, int funct, int imm, int jmp)
        {
            Ins = ins;
            Rs = rs;
            Rt = rt;
            Rd = rd;
            Shamt = shamt;
            Funct = funct;
            Opcode = opcode;
            Imm = imm;
            Jmp = jmp;
        }
    }
}
