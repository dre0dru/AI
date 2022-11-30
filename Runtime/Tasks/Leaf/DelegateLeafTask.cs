using System;
using Dre0Dru.DynamicContext;

namespace Dre0Dru.BehaviourTree.Tasks.Leaf
{
    public class DelegateLeafTask : TaskBase
    {
        private readonly Func<float, IDynamicContext<string>, TaskStatus> _processFunc;

        public DelegateLeafTask(Func<float, IDynamicContext<string>, TaskStatus> processFunc)
        {
            _processFunc = processFunc;
        }

        protected override TaskStatus OnTick(float dt)
        {
            return _processFunc(dt, Context);
        }
    }
}
