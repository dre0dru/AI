using System;
using UnityEngine;

namespace Dre0Dru.BehaviourTree.Tasks.Leaf
{
    [Serializable, AddTypeMenu("Leaf/Wait Until")]
    public class WaitUntil : TaskBase
    {
        [SerializeReference, SubclassSelector]
        private ITask _condition;

        public WaitUntil() : this(null)
        {
        }

        public WaitUntil(ITask condition)
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

            return TaskStatus.Running;
        }

        protected override void OnReset() =>
            _condition.Reset();
    }
}
