using System;
using Dre0Dru.DynamicContext;
using UnityEngine;

namespace Dre0Dru.BehaviourTree.Tasks.Decorator
{
    [Serializable, AddTypeMenu("Decorator/Dependency")]
    public class DependencyTask : DecoratorTask
    {
        [SerializeReference, SubclassSelector]
        private ITask _dependency;

        public DependencyTask() : this(null, null)
        {
        }

        public DependencyTask(ITask decorated, ITask dependency) : base(decorated)
        {
            _dependency = dependency;
        }

        public DependencyTask SetDependency<TTask>(TTask dependency)
            where TTask : ITask
        {
            _dependency = dependency;

            return this;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            _dependency.Initialize();
        }

        protected override TaskStatus OnTick(float dt)
        {
            var dependencyStatus = _dependency.Tick(dt);

            switch (dependencyStatus)
            {
                case TaskStatus.Success:
                    break;
                case TaskStatus.Failure:
                    return TaskStatus.Failure;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dependencyStatus));
            }
            
            return _decorated.Tick(dt);
        }

        protected override void OnReset()
        {
            base.OnReset();
            _dependency.Reset();
        }

        public override void SetContext(IDynamicContext<string> context)
        {
            base.SetContext(context);
            _dependency.SetContext(context);
        }
    }
}
