namespace Dre0Dru.BehaviourTree
{
    public interface IDecoratorTask
    {
        //TODO as non-generic, just by interface?
        void SetDecorated<TTask>(TTask decorated)
            where TTask : ITask;
    }
}
