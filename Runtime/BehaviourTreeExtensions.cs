using Dre0Dru.Contextual;
using Dre0Dru.DynamicContext;

namespace Dre0Dru.BehaviourTree
{
    public static class BehaviourTreeExtensions
    {
        public static void Initialize(this ITask task, IDynamicContext<string> dynamicContext) =>
            task.PassContext(dynamicContext).Initialize();
    }
}
