using System;
using UnityEngine;

namespace Dre0Dru.BehaviourTree.Tasks.Decorator
{
    [Serializable, AddTypeMenu("Decorator/Repeat Until")]
    public class RepeatUntilTask : DecoratorTask
    {
        [SerializeReference, SubclassSelector]
        private ITask _condition;

        public RepeatUntilTask() : this(null, null)
        {
            
        }
        
        public RepeatUntilTask(ITask decorated, ITask condition) : base(decorated)
        {
            _condition = condition;
        }

        protected override TaskStatus OnTick(float dt)
        {
            var conditionStatus = _condition.Tick(dt);

            if (conditionStatus == TaskStatus.Success)
            {
                return TaskStatus.Success;
            }

            _decorated.Tick(dt);

            return TaskStatus.Running;
        }

        protected override void OnReset()
        {
            base.OnReset();
            _condition.Reset();
        }
    }
}