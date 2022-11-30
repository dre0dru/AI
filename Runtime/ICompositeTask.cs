namespace Dre0Dru.BehaviourTree
{
    public interface ICompositeTask
    {
        //TODO as non-generic, just by interface?
        void AddChild<TTask>(TTask child)
            where TTask : ITask;
    }
}
