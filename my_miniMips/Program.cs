using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_miniMips
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment env = new Environment();
			//env.StackLimit = BinaryLoader.Loadbinary(env, args[0]);
			env.StackLimit = BinaryLoader.Loadbinary(env, "../../lol");

            env.CPU.run();

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
