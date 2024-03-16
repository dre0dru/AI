using Dre0Dru.Blackboard;

namespace Dre0Dru.BehaviourTree
{
    public static class NodeExtensions
    {
        public static void SetBlackboardRecursively(this INode root, IBlackboard blackboard)
        {
            root.Blackboard = blackboard;
            
            foreach (var childNode in root)
            {
                childNode.SetBlackboardRecursively(blackboard);
            }
        }
    }
}
