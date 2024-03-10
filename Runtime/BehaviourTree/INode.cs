using System.Collections.Generic;
using Dre0Dru.Blackboard;

namespace Dre0Dru.BehaviourTree
{
    //TODO IEnumerable?
    //TODO Atomics?
    //TODO Blackboard?
    public interface INode : IEnumerable<INode>
    {
        NodeStatus Status { get; }

        IBlackboard Blackboard { get; set; }
        
        NodeStatus Tick(float dt);

        void Abort(NodeStatus abortStatus);
    }
}
