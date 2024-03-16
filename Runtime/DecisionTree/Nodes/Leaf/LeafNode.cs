using System;
using System.Collections.Generic;

namespace Dre0Dru.DecisionTree
{
    [Serializable]
    public abstract class LeafNode<TResult, TQuery> : Node<TResult, TQuery>
    {
        public override IEnumerator<INode<TResult, TQuery>> GetEnumerator()
        {
            yield break;
        }
    }
}
