using System;
using System.Collections;
using System.Collections.Generic;
using Dre0Dru.Blackboard;
using UnityEngine;
using UnityEngine.Scripting;

namespace Dre0Dru.DecisionTree
{
    [Serializable]
    public class FromAsset<TResult, TQuery> : INode<TResult, TQuery>
    {
        [SerializeField]
        private NodeAsset<TResult, TQuery> _node;

        public IBlackboard Blackboard
        {
            get => _node.Blackboard;
            set => _node.Blackboard = value;
        }

        [RequiredMember]
        public FromAsset()
        {
        }

        public FromAsset(NodeAsset<TResult, TQuery> node)
        {
            _node = node;
        }

        public bool Evaluate(TQuery query, out TResult result)
        {
            return _node.Evaluate(query, out result);
        }

        public IEnumerator<INode<TResult, TQuery>> GetEnumerator()
        {
            return _node.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_node).GetEnumerator();
        }
    }
}
