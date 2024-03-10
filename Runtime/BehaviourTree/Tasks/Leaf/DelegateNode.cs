using System;

namespace Dre0Dru.BehaviourTree.Tasks.Leaf
{
    [Serializable]
    public class DelegateNode : LeafNode
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
