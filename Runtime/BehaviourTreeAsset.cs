using Dre0Dru.GameAssets;
using UnityEngine;

namespace Dre0Dru.BehaviourTree
{
    [CreateAssetMenu(fileName = nameof(BehaviourTreeAsset), menuName = "Behaviour Trees/" + nameof(BehaviourTreeAsset))]
    public class BehaviourTreeAsset : ScriptableObject, IDataAsset<BehaviourTree>
    {
        [SerializeField]
        protected BehaviourTree _behaviourTree;

        public BehaviourTree Data => _behaviourTree;
    }
}
