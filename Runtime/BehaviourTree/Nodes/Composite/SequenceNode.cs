using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.BehaviourTree
{
    [Serializable]
    public class SequenceNode : CompositeNode
    {
        [SerializeField]
        private int _currentChildIndex;

        public SequenceNode() : base()
        {
        }

        public SequenceNode(IList<INode> children) : base(children)
        {
        }

        public SequenceNode(params INode[] children) : base(children)
        {
        }

        protected override NodeStatus OnTick(float dt)
        {
            var status = Children[_currentChildIndex].Tick(dt);

            switch (status)
            {
                case NodeStatus.Success:
                {
                    _currentChildIndex++;

                    if (_currentChildIndex >= Count)
                    {
                        return NodeStatus.Success;
                    }

                    return NodeStatus.Running;
                }
                case NodeStatus.Running:
                case NodeStatus.Failure:
                    return status;
                default: throw new ArgumentOutOfRangeException(nameof(status), status, string.Empty);
            }
        }

        protected override void OnStart()
        {
            _currentChildIndex = 0;
        }
    }
}
