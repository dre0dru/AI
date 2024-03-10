using System;
using UnityEngine;

namespace Dre0Dru.BehaviourTree.Tasks.Leaf
{
    [Serializable]
    public class WaitForSecondsNode : LeafNode
    {
        [SerializeField]
        private float _seconds;

        [SerializeField]
        private float _currentSeconds;

        public WaitForSecondsNode()
        {
        }

        public WaitForSecondsNode(float seconds)
        {
            _seconds = seconds;
        }

        protected override void OnStart()
        {
            _currentSeconds = 0;
        }

        protected override NodeStatus OnTick(float dt)
        {
            _currentSeconds += dt;

            return _currentSeconds >= _seconds ? NodeStatus.Success : NodeStatus.Running;
        }
    }
}
