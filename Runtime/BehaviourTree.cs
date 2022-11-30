using System;
using Dre0Dru.DynamicContext;
using UnityEngine;

namespace Dre0Dru.BehaviourTree
{
    //TODO async UniTask variant
    //TODO as IEnumerable with ability to iterate over every child?
    //TODO continuation options: reset/restart on failure/success, stop, etc.
    //TODO can it be made just as Task with several continuation options?
    //TODO behaviour tree component? 
    [Serializable]
    public class BehaviourTree : ITask
    {
        [SerializeReference, SubclassSelector]
        private ITask _root;

        public BehaviourTree(ITask root)
        {
            _root = root;
        }

        public void Initialize() =>
            _root.Initialize();

        public TaskStatus Tick(float dt) =>
            _root.Tick(dt);

        public void Reset() =>
            _root.Reset();

        public void SetContext(IDynamicContext<string> context) =>
            _root.SetContext(context);
    }
}
