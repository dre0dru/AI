namespace Dre0Dru.BehaviourTree
{
    //TODO IEnumerable?
    //TODO Atomics?
    //TODO Blackboard?
    public interface INode
    {
        NodeStatus Status { get; }
        
        NodeStatus Tick(float dt);

        void Abort(NodeStatus abortStatus);
    }
}
