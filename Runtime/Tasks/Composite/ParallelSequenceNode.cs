using System.Collections.Generic;

namespace Dre0Dru.BehaviourTree.Tasks.Composite
{
    public class ParallelSequenceNode : CompositeNode
    {
        private readonly List<NodeStatus> _childrenLeftToExecute = new List<NodeStatus>();

        public ParallelSequenceNode()
        {
        }

        public ParallelSequenceNode(IList<INode> children) : base(children)
        {
        }

        public ParallelSequenceNode(params INode[] children) : base(children)
        {
        }

        protected override void OnStart()
        {
            _childrenLeftToExecute.Clear();
            for (int i = 0; i < Count; i++)
            {
                _childrenLeftToExecute.Add(NodeStatus.Running);
            }
        }

        protected override NodeStatus OnTick(float dt)
        {
            var isRunning = false;
            for (int i = 0; i < _childrenLeftToExecute.Count; ++i)
            {
                if (_childrenLeftToExecute[i] == NodeStatus.Running)
                {
                    var status = Children[i].Tick(dt);
                    if (status == NodeStatus.Failure)
                    {
                        AbortRunningChildren();
                        return NodeStatus.Failure;
                    }

                    if (status == NodeStatus.Running)
                    {
                        isRunning = true;
                    }

                    _childrenLeftToExecute[i] = status;
                }
            }

            return isRunning ? NodeStatus.Running : NodeStatus.Success;
        }

        private void AbortRunningChildren()
        {
            foreach (var child in Children)
            {
                if (child.Status == NodeStatus.Running)
                {
                    child.Abort(NodeStatus.Failure);
                }
            }
        }
    }
}
