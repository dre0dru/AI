using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Dre0Dru.BehaviourTree.Tasks.Composite
{
    [Serializable, AddTypeMenu("Composite/Random Selector")]
    public class RandomSelectorTask : CompositeTask
    {
        private int _randomChildIndex;

        public RandomSelectorTask()
        {
        }

        public RandomSelectorTask(List<ITask> children) : base(children)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            _randomChildIndex = Random.Range(0, Count);
        }

        protected override TaskStatus OnTick(float dt)
        {
            return _children[_randomChildIndex].Tick(dt);
        }
    }
}
