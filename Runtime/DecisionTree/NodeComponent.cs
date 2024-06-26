﻿using System.Collections;
using System.Collections.Generic;
using Dre0Dru.Blackboard;
using UnityEngine;

namespace Dre0Dru.DecisionTree
{
    public class NodeComponent<TQuery, TResult> : MonoBehaviour, INode<TQuery, TResult>
    {
        [SerializeReference]
        private INode<TQuery, TResult> _root;

        public IBlackboard Blackboard
        {
            get => _root.Blackboard;
            set => _root.Blackboard = value;
        }

        public bool Evaluate(TResult query, out TQuery result)
        {
            return _root.Evaluate(query, out result);
        }

        public IEnumerator<INode<TQuery, TResult>> GetEnumerator()
        {
            return _root.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_root).GetEnumerator();
        }
    }
}
