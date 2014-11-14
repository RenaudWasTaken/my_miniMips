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

        private int _stackBase;

        public Environment()
        {
            RAM = new byte[64 * 1024]; //64Kib RAM
            _stackBase = RAM.Length - 1;
            CPU = new CPU(this);
        }

        public void stack_push(int data) 
        {
        }         

        public void stack_push(short data) 
        { }         

        public void stack_push(byte data) 
        { }

        public void stack_push(byte[] data)
        {
            foreach (byte b in data)
            {
                       
            }
        }         
    }
}
