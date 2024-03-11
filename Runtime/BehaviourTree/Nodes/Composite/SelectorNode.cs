using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.BehaviourTree
{
    [Serializable]
    public class SelectorNode : CompositeNode
    {
        [SerializeField]
        private int _currentChildIndex;

        public SelectorNode()
        {
        }

        public SelectorNode(IList<INode> children) : base(children)
        {
        }

        public SelectorNode(params INode[] children) : base(children)
        {
        }

        protected override void OnStart()
        {
            _currentChildIndex = 0;
        }

        protected override NodeStatus OnTick(float dt)
        {
            var status = Children[_currentChildIndex].Tick(dt);

            switch (status)
            {
                case NodeStatus.Running:
                case NodeStatus.Success:
                    return status;
                case NodeStatus.Failure:
                {
                    _currentChildIndex++;

                    if (_currentChildIndex >= Count)
                    {
                        return NodeStatus.Failure;
                    }

                    return NodeStatus.Running;
                }
                default: throw new ArgumentOutOfRangeException(nameof(status));
            }
        }
    }
}
