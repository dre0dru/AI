using Dre0Dru.Buildables;

namespace Dre0Dru.BehaviourTree.Builder
{
    public static class TaskBuilder
    {
        public static Buildable<T> WithRootNode<T>(T root)
            where T : ITask
        {
            return new Buildable<T>(root);
        }
        
        public static Buildable<T> WithRootNode<T>()
            where T : ITask, new()
        {
            return new Buildable<T>(new T());
        }
    }
}
