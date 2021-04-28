using CleverCrow.Fluid.BTs.Samples;
using CleverCrow.Fluid.BTs.Trees;
using System;
using CleverCrow.Fluid.BTs.Tasks;

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

            var _tree = new BehaviorTreeBuilder(/*gameObject*/null)
           .Sequence()
               .Condition("Custom Condition", () => {
                   return true;
               })
               .Do("Custom Action", () => {
                   return TaskStatus.Success;
               })
           .End()
           .Build();
            _tree.Tick();

            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
