using System.Collections.Generic;
using Dre0Dru.Blackboard;

namespace Dre0Dru.DecisionTree
{
    public interface INode<TResult, in TQuery> : IEnumerable<INode<TResult, TQuery>>
    {
        IBlackboard Blackboard { get; set; }

        bool Evaluate(TQuery query, out TResult result);
    }
}
