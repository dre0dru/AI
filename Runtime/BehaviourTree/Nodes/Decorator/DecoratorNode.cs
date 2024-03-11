using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.BehaviourTree
{
    //TODO wait until, condition w/ aborts, 
    [Serializable]
    public abstract class DecoratorNode : Node
    {
        [SerializeReference]
        private INode _decorated;

        protected internal INode Decorated => _decorated;

        protected DecoratorNode()
        {
        }

        protected DecoratorNode(INode decorated)
        {
            _decorated = decorated;
        }

        public DecoratorNode SetDecorated(INode decorated)
        {
            _decorated = decorated;
            return this;
        }
        
        public override IEnumerator<INode> GetEnumerator()
        {
            yield return _decorated;
        }
    }
}
