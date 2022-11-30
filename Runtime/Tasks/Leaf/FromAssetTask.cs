using System;
using Dre0Dru.GameAssets;
using UnityEngine;

namespace Dre0Dru.BehaviourTree.Tasks.Leaf
{
    [Serializable, AddTypeMenu("Leaf/From Asset")]
    public class FromAssetTask : TaskBase
    {
        [SerializeField]
        private TaskAsset _taskAsset;

        [SerializeReference]
        private ITask _task;

        protected override void OnInitialize()
        {
            _taskAsset.CreateCopyAndExtractData(out _task);
            _task.Initialize();
        }

        protected override TaskStatus OnTick(float dt) =>
            _task.Tick(dt);
    }
}
