using System;

namespace Dre0Dru.BehaviourTree.Tasks.Leaf
{
    public class DelegateNode : Node
    {
        private readonly Func<float, NodeStatus> _delegate;

        public DelegateNode(Func<float, NodeStatus> @delegate)
        {
            _delegate = @delegate;
        }

        protected override NodeStatus OnTick(float dt)
        {
            return _delegate(dt);
        }
    }
}
