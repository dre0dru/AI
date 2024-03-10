using UnityEngine;

namespace Dre0Dru.BehaviourTree
{
    [CreateAssetMenu(menuName = "Dre0Dru/Behaviour Tree/Node Asset", fileName = "Node Asset")]
    public class NodeAsset : ScriptableObject, INode
    {
        [SerializeReference]
        private INode _root;

        public NodeStatus Status => _root.Status;

        public NodeStatus Tick(float dt)
        {
            return _root.Tick(dt);
        }

        public void Abort(NodeStatus abortStatus)
        {
            _root.Abort(abortStatus);
        }
    }
}
