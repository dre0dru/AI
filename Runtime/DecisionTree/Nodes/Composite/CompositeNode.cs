using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace Dre0Dru.DecisionTree
{
    [Serializable]
    public abstract class CompositeNode<TResult, TQuery> : Node<TResult, TQuery>
    {
        [SerializeReference]
        private List<INode<TResult, TQuery>> _children;

        protected internal IList<INode<TResult, TQuery>> Children => _children;
        protected internal int Count => _children.Count;

        [RequiredMember]
        protected CompositeNode() : this(new List<INode<TResult, TQuery>>())
        {
            
        }
        
        protected CompositeNode(List<INode<TResult, TQuery>> children)
        {
            _children = children;
        }
        
        protected CompositeNode(params INode<TResult, TQuery>[] children)
        {
            _children = new List<INode<TResult, TQuery>>(children);
        }

        public CompositeNode<TResult, TQuery> AddChild(INode<TResult, TQuery> child)
        {
            _children.Add(child);
            return this;
        }
        
        public override IEnumerator<INode<TResult, TQuery>> GetEnumerator()
        {
            return _children.GetEnumerator();
        }
    }
}
