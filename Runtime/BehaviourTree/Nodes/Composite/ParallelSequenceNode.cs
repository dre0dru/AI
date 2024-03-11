using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.BehaviourTree
{
    [Serializable]
    public class ParallelSequenceNode : CompositeNode
    {
        [SerializeField]
        private List<NodeStatus> _childrenLeftToExecute = new List<NodeStatus>();

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
