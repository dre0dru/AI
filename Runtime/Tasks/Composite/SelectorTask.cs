using System;
using System.Collections.Generic;

namespace Dre0Dru.BehaviourTree.Tasks.Composite
{
    [Serializable, AddTypeMenu("Composite/Selector")]
    public class SelectorTask : CompositeTask
    {
        private int _currentChildIndex;

        public SelectorTask()
        {
        }

        public SelectorTask(List<ITask> children) : base(children)
        {
        }

        protected override TaskStatus OnTick(float dt)
        {
            var status = _children[_currentChildIndex].Tick(dt);

            switch (status)
            {
                case TaskStatus.Running:
                    return TaskStatus.Running;
                case TaskStatus.Failure:
                {
                    _currentChildIndex++;
                    
                    if (_currentChildIndex >= Count)
                    {
                        return TaskStatus.Failure;
                    }
                    
                    break;
                }
                case TaskStatus.Success:
                {
                    return TaskStatus.Success;
                }
                default: throw new ArgumentOutOfRangeException(nameof(status));
            }
            
            return TaskStatus.Running;
        }
        
        protected override void OnReset()
        {
            base.OnReset();
            _currentChildIndex = 0;
        }
    }
}
