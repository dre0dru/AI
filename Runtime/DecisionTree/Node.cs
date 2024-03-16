using System;
using System.Collections;
using System.Collections.Generic;
using Dre0Dru.Blackboard;

namespace Dre0Dru.DecisionTree
{
    [Serializable]
    public abstract class Node<TResult, TQuery> : INode<TResult, TQuery>
    {
        public IBlackboard Blackboard { get; set; }

        public bool Evaluate(TQuery query, out TResult result)
        {
            OnStart();
            var isSuccess = OnEvaluate(query, out result);
            OnFinish();
            return isSuccess;
        }

        protected virtual void OnStart()
        {
        }

        protected abstract bool OnEvaluate(TQuery query, out TResult result);

        protected virtual void OnFinish()
        {
        }

        public abstract IEnumerator<INode<TResult, TQuery>> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
