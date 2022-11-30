using System;
using Dre0Dru.DynamicContext;
using UnityEngine;

namespace Dre0Dru.BehaviourTree.Tasks.Decorator
{
    [Serializable]
    public abstract class DecoratorTask : TaskBase, IDecoratorTask
    {
        [SerializeReference, SubclassSelector]
        protected ITask _decorated;

        protected DecoratorTask() : this(null)
        {
        }
        
        protected DecoratorTask(ITask decorated)
        {
            _decorated = decorated;
        }

        public void SetDecorated<TTask>(TTask decorated)
            where TTask : ITask
        {
            _decorated = decorated;
        }

        protected override void OnInitialize()
        {
            _decorated.Initialize();
        }

        protected override void OnReset()
        {
            _decorated.Reset();
        }

        public override void SetContext(IDynamicContext<string> context)
        {
            base.SetContext(context);
            _decorated.SetContext(context);
        }
    }
}
