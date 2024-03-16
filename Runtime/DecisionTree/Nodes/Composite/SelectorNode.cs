using System;
using System.Collections.Generic;

namespace Dre0Dru.DecisionTree
{
    [Serializable]
    public class SelectorNode<TResult, TQuery> : CompositeNode<TResult, TQuery>
    {
        public SelectorNode()
        {
        }

        public SelectorNode(List<INode<TResult, TQuery>> children) : base(children)
        {
        }

        public SelectorNode(params INode<TResult, TQuery>[] children) : base(children)
        {
        }

        protected override bool OnEvaluate(TQuery query, out TResult result)
        {
            foreach (var child in Children)
            {
                if (child.Evaluate(query, out result))
                {
                    return true;
                }
            }

            result = default;
            return false;
        }
    }
}
