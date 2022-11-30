using Dre0Dru.Buildables;
using Dre0Dru.Contextual;
using Dre0Dru.DynamicContext;

namespace Dre0Dru.BehaviourTree.Builder
{
    public static partial class BuilderExtensions
    {
        public static BehaviourTree AsBehaviourTree<TTask>(this Buildable<TTask> buildable)
            where TTask : ITask
        {
            return new BehaviourTree(buildable.Unwrap());
        }

        public static BehaviourTree WithContext(this BehaviourTree behaviourTree, IDynamicContext<string> context) =>
            behaviourTree.PassContext(context);
    }
}
