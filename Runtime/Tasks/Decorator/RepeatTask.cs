using System;
using UnityEngine;

namespace Dre0Dru.BehaviourTree.Tasks.Decorator
{
    [Serializable, AddTypeMenu("Decorator/Repeat")]
    public class RepeatTask : DecoratorTask
    {
        [SerializeField]
        private int _times;

        private int _counter;

        public RepeatTask() : this(null, 0)
        {
            
        }
        
        public RepeatTask(ITask decorated, int times) : base(decorated)
        {
            _times = times;
            _counter = 0;
        }

        protected override TaskStatus OnTick(float dt)
        {
            var status = _decorated.Tick(dt);

            switch (status)
            {
                case TaskStatus.Success:
                {
                    _counter++;

                    if (_counter >= _times)
                    {
                        return TaskStatus.Success;
                    }

                    return TaskStatus.Running;
                }
                case TaskStatus.Running:
                    return TaskStatus.Running;
                case TaskStatus.Failure:
                {
                    return TaskStatus.Failure;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected override void OnReset()
        {
            base.OnReset();
            _counter = 0;
        }
    }
}
