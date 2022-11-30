using Dre0Dru.GameAssets;
using UnityEngine;

namespace Dre0Dru.BehaviourTree
{
    [CreateAssetMenu(fileName = nameof(TaskAsset), menuName = "Behaviour Trees/" + nameof(TaskAsset))]
    public class TaskAsset : ScriptableObject, IDataAsset<ITask>
    {
        [SerializeReference, SubclassSelector]
        protected ITask _root;

        public ITask Data => _root;
    }
}
