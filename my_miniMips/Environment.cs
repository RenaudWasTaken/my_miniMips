using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_miniMips
{
    class Environment
    {
        public byte[] RAM { get; private set; }
        public CPU CPU { get; set; }

        public int StackBase
        {
            get { return RAM.Length - 1; }
        }

        public int StackLimit { get; set; }

        public Environment()
        {
            RAM = new byte[64 * 1024]; //64Kib RAM
            CPU = new CPU(this);
        }

        #region stack_push

        public void stack_push(int data) 
        {
            stack_push(BitConverter.GetBytes(data));
        }

        public void stack_push(short data)
        {
            stack_push(BitConverter.GetBytes(data));
        }

        public void stack_push(byte data)
        {
            stack_push(new [] { data });
        }

        public void stack_push(byte[] data)
        {
            CPU.AddSP(data.Length);

            for (int i = 0; i < data.Length; i++)
                RAM[CPU.GetSP() + i] = data[i];
        }

        #endregion

        #region stack_pop

        public int stack_pop_int()
        {
            return BitConverter.ToInt32(stack_pop_bytes(4), 0);
        }
        
        public short stack_pop_short()
        {
            return BitConverter.ToInt16(stack_pop_bytes(2), 0);
        }
        
        public byte stack_pop_byte()
        {
            return stack_pop_bytes(1)[0];
        }
        
        public byte[] stack_pop_bytes(int size)
        {
            int sp = CPU.GetSP();
            CPU.SubSP(size);

            byte[] datas = new byte[size];

            for (int i = 0; i < size; i++)
                datas[i] = RAM[sp + i];

            return datas;
        }

        #endregion
    }
}
