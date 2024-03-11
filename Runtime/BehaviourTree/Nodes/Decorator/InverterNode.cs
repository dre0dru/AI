using System;

namespace Dre0Dru.BehaviourTree
{
    [Serializable]
    public class InverterNode : DecoratorNode
    {
        public InverterNode()
        {
        }

        public InverterNode(INode decorated) : base(decorated)
        {
        }

        protected override NodeStatus OnTick(float dt)
        {
            var status = Decorated.Tick(dt);

            return status switch
            {
                NodeStatus.Success => NodeStatus.Failure,
                NodeStatus.Running => NodeStatus.Running,
                NodeStatus.Failure => NodeStatus.Success,
                _ => throw new ArgumentOutOfRangeException(nameof(status), status, string.Empty)
            };
        }
    }
}
