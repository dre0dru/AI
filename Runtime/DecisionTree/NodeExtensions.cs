using Dre0Dru.Blackboard;

namespace Dre0Dru.DecisionTree
{
    public static class NodeExtensions
    {
        public static void SetBlackboardRecursively<TResult, TQuery>(this INode<TResult, TQuery> root, IBlackboard blackboard)
        {
            root.Blackboard = blackboard;
            
            foreach (var childNode in root)
            {
                childNode.SetBlackboardRecursively(blackboard);
            }
        }

        public static TResult Evaluate<TResult, TQuery>(this INode<TResult, TQuery> node, TQuery query)
        {
            node.Evaluate(query, out var result);
            return result;
        }
    }
}
