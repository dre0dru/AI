using System;
using System.Collections.Generic;

namespace Dre0Dru.BehaviourTree.Tasks.Composite
{
    [Serializable, AddTypeMenu("Composite/Sequence")]
    public class SequenceTask : CompositeTask
    {
        private int _currentChildIndex;

        public SequenceTask()
        {
        }

        public SequenceTask(List<ITask> children) : base(children)
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
                    return TaskStatus.Failure;
                }
                case TaskStatus.Success:
                {
                    _currentChildIndex++;

                    if (_currentChildIndex >= Count)
                    {
                        return TaskStatus.Success;
                    }
                    
                    break;
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
