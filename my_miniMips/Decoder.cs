using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_miniMips
{
    class Decoder
    {
        public Instruction decode_instruction(int instruction)
        {
            return new Instruction(instruction,
                get_opcode(instruction),
                get_rs(instruction),
                get_rt(instruction),
                get_rd(instruction),
                get_shamt(instruction),
                get_funct(instruction),
                get_imm(instruction),
                get_jmp(instruction));
        }

        private int get_opcode(int instruction) { return (instruction & unchecked((int)0xFA000000)) >> 26; }
        private int get_rs    (int instruction) { return (instruction & unchecked((int)0x03E00000)) >> 21; }
        private int get_rt    (int instruction) { return (instruction & unchecked((int)0x001F0000)) >> 16; }
        private int get_rd    (int instruction) { return (instruction & unchecked((int)0x0000F800)) >> 11; }
        private int get_shamt (int instruction) { return (instruction & unchecked((int)0x000007A0)) >> 6; }
        private int get_funct (int instruction) { return (instruction & unchecked((int)0x0000003F)); }
        private int get_imm   (int instruction) { return (instruction & unchecked((int)0x000000FF)); }
		private int get_jmp   (int instruction) { return (instruction & unchecked((int)0x0000FFFF)); }
    }
}
