using Dre0Dru.Contextual;
using Dre0Dru.DynamicContext;

namespace Dre0Dru.BehaviourTree
{
    public interface ITask : IContextual<IDynamicContext<string>>
    {
        void Initialize();
        
        TaskStatus Tick(float dt);

        void Reset();
    }
}
