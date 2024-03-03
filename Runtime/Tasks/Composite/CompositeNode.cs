using System.Collections.Generic;

namespace Dre0Dru.BehaviourTree.Tasks.Composite
{
    public abstract class CompositeNode : Node
    {
        private readonly IList<INode> _children;

        protected internal IList<INode> Children => _children;
        protected internal int Count => _children.Count;

        protected CompositeNode() : this(new List<INode>())
        {
            
        }
        
        protected CompositeNode(IList<INode> children)
        {
            _children = children;
        }

        public CompositeNode AddChild(INode child)
        {
            _children.Add(child);
            return this;
        }
    }
}
