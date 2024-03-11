using System.Collections.Generic;
using Dre0Dru.Blackboard;

namespace Dre0Dru.BehaviourTree
{
    public interface INode : IEnumerable<INode>
    {
        NodeStatus Status { get; }

        IBlackboard Blackboard { get; set; }
        
        NodeStatus Tick(float dt);

        void Abort(NodeStatus abortStatus);
    }
}
