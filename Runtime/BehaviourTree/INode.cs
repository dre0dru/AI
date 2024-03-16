using System.Collections.Generic;
using Dre0Dru.Blackboard;

namespace Dre0Dru.BehaviourTree
{
    //TODO since 2023.2 Unity can ser ref generic interfaces
    //create generic INode<TInput, TOutput> with generic
    //composite/decorator nodes
    public interface INode : IEnumerable<INode>
    {
        NodeStatus Status { get; }

        IBlackboard Blackboard { get; set; }
        
        NodeStatus Tick(float dt);

        void Abort(NodeStatus abortStatus);
    }
}
