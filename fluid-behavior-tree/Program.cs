using CleverCrow.Fluid.BTs.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fluid_behavior_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            var t = new DecoratorRepeatWithWait();
            Console.WriteLine("Start T");
            t.Start();
            t.Update();

            var t2 = new TreeTestSample();
            Console.WriteLine("Start T2");
            t2.Awake();
            t2.Update();
            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
