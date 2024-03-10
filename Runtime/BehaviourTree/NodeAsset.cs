using System.Collections;
using System.Collections.Generic;
using Dre0Dru.Blackboard;
using UnityEngine;

namespace Dre0Dru.BehaviourTree
{
    [CreateAssetMenu(menuName = "Dre0Dru/Behaviour Tree/Node Asset", fileName = "Node Asset")]
    public class NodeAsset : ScriptableObject, INode
    {
        [SerializeReference]
        private INode _root;

        public NodeStatus Status => _root.Status;
        public IBlackboard Blackboard
        {
            get => _root.Blackboard;
            set => _root.Blackboard = value;
        }

        public NodeStatus Tick(float dt)
        {
            return _root.Tick(dt);
        }

        public void Abort(NodeStatus abortStatus)
        {
            _root.Abort(abortStatus);
        }

        public IEnumerator<INode> GetEnumerator()
        {
            return _root.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_root).GetEnumerator();
        }
    }
}
