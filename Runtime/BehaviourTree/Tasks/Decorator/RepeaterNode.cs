using System;

namespace Dre0Dru.BehaviourTree.Tasks.Decorator
{
    public class RepeaterNode : DecoratorNode
    {
        private readonly int _count;

        private int _counter;

        public RepeaterNode(INode decorated, int count) : base(decorated)
        {
            _count = count;
        }

        protected override void OnStart()
        {
            _counter = 0;
        }

        protected override NodeStatus OnTick(float dt)
        {
            var status = Decorated.Tick(dt);

            switch (status)
            {
                case NodeStatus.Success:
                {
                    _counter++;

                    if (_counter >= _count)
                    {
                        return NodeStatus.Success;
                    }

                    return NodeStatus.Running;
                }
                case NodeStatus.Running:
                    return NodeStatus.Running;
                case NodeStatus.Failure:
                    return NodeStatus.Failure;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, string.Empty);
            }
        }
    }
}
