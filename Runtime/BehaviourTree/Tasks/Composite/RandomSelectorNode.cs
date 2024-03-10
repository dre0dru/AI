using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Dre0Dru.BehaviourTree.Tasks.Composite
{
    [Serializable]
    public class RandomSelectorNode : CompositeNode
    {
        [SerializeField]
        private int _randomChildIndex;

        internal int RandomChildIndex => _randomChildIndex;

        public RandomSelectorNode()
        {
        }

        public RandomSelectorNode(IList<INode> children) : base(children)
        {
        }

        public RandomSelectorNode(params INode[] children) : base(children)
        {
        }

        protected override void OnStart()
        {
            _randomChildIndex = Random.Range(0, Count);
        }

        protected override NodeStatus OnTick(float dt)
        {
            return Children[_randomChildIndex].Tick(dt);
        }
    }
}
