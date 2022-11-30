using System;

namespace Dre0Dru.BehaviourTree.Tasks.Decorator
{
    [Serializable, AddTypeMenu("Decorator/Inverter")]
    public class InverterTask : DecoratorTask
    {
        public InverterTask() : this(null)
        {
        }

        public InverterTask(ITask decorated) : base(decorated)
        {
        }

        protected override TaskStatus OnTick(float dt)
        {
            var status = _decorated.Tick(dt);

            return status switch
            {
                TaskStatus.Success => TaskStatus.Failure,
                TaskStatus.Running => TaskStatus.Running,
                TaskStatus.Failure => TaskStatus.Success,
                _ => throw new ArgumentOutOfRangeException(nameof(status))
            };
        }
    }
}
