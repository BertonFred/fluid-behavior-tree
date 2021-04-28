using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;

namespace CleverCrow.Fluid.BTs.Samples {
    public class DecoratorRepeatWithWait /*: MonoBehaviour*/ {
        private BehaviorTree _tree;

        private bool _toggle;

        public void Start () {
            _tree = new BehaviorTreeBuilder(/*gameObject*/this)
                .RepeatForever()
                    .Parallel()

                        .Sequence()
                            .Do(() => {
                                _toggle = true;
                                return TaskStatus.Success;
                            })
                            //.WaitTime()
                            .Do(() => {
                                _toggle = false;
                                return TaskStatus.Success;
                            })
                            //.WaitTime()
                        .End()

                        .Sequence()
                            .Do(() => TaskStatus.Success)
                            .RepeatUntilSuccess()
                                .Sequence()
                                    //.WaitTime()
                                    .Do(() => /*Random.value*/1 > 0.5f ? TaskStatus.Success : TaskStatus.Failure)
                                .End()
                            .End()
                        .End()

                    .End()
                .End()
            .Build();
        }

        public void Update () {
            _tree.Tick();
        }
    }
}
