using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.BehaviourTree
{
    [Serializable]
    public abstract class CompositeNode : Node
    {
        [SerializeReference]
        private List<INode> _children;

        protected internal IList<INode> Children => _children;
        protected internal int Count => _children.Count;

        protected CompositeNode() : this(new List<INode>())
        {
        }

        protected CompositeNode(List<INode> children)
        {
            _children = children;
        }

        protected CompositeNode(params INode[] children)
        {
            _children = new List<INode>(children);
        }

        public CompositeNode AddChild(INode child)
        {
            _children.Add(child);
            return this;
        }

        public override IEnumerator<INode> GetEnumerator()
        {
            return _children.GetEnumerator();
        }
    }
}
