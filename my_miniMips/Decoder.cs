using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_miniMips
{
    class Decoder
    {
        public void decode_instruction(int instruction, out int opcode, out int rs, out int rt, out int rd,
                                       out int shamt, out int funct, out int imm, out int jmp)
        {
            rd = 0; rs = 0; rt = 0;
            opcode = this.get_opcode(instruction);

            rd = this.get_rd(instruction);
            rs = this.get_rs(instruction);
            rt = this.get_rt(instruction);

            shamt = this.get_shamt(instruction);
            funct = this.get_funct(instruction);

            imm = this.get_imm(instruction);
            jmp = this.get_jmp(instruction);
     
        }

        private int get_opcode(int instruction) { return instruction & unchecked((int)0xFA000000); }
        private int get_rs    (int instruction) { return instruction & unchecked((int)0x03C00000); }
        private int get_rt    (int instruction) { return instruction & unchecked((int)0x001F0000); }
        private int get_rd    (int instruction) { return instruction & unchecked((int)0x000F8000); }
        private int get_shamt (int instruction) { return instruction & unchecked((int)0x000007A0); }
        private int get_funct (int instruction) { return instruction & unchecked((int)0x0000003F); }
        private int get_imm   (int instruction) { return instruction & unchecked((int)0x000000FF); }
        private int get_jmp   (int instruction) { return instruction & unchecked((int)0x01FFFFFF); }

    }
}
