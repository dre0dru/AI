using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace Dre0Dru.DecisionTree
{
    [Serializable]
    public abstract class DecoratorNode<TResult, TQuery> : Node<TResult, TQuery>
    {
        [SerializeReference]
        private INode<TResult, TQuery> _decorated;

        protected internal INode<TResult, TQuery> Decorated => _decorated;

        [RequiredMember]
        protected DecoratorNode()
        {
        }

        protected DecoratorNode(INode<TResult, TQuery> decorated)
        {
            _decorated = decorated;
        }

        public DecoratorNode<TResult, TQuery> SetDecorated(INode<TResult, TQuery> decorated)
        {
            _decorated = decorated;
            return this;
        }
        
        public override IEnumerator<INode<TResult, TQuery>> GetEnumerator()
        {
            yield return _decorated;
        }
    }
}
