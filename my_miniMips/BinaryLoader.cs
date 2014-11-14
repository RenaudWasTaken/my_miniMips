using System;
using System.IO;

namespace my_miniMips
{
    static class BinaryLoader
    {
        public static int Loadbinary(Environment env, string path)
        {
           if (!File.Exists(path))
               throw new Exception("File not found");

            BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open));
            byte[] datas = br.ReadBytes((int) br.BaseStream.Length);

            for (int i = 0; i < datas.Length; i++)
                env.RAM[i] = datas[i];

            return datas.Length;
        }
    }
}
