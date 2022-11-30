using System;
using Dre0Dru.DynamicContext;

namespace Dre0Dru.BehaviourTree
{
    public abstract class TaskBase : ITask
    {
        [NonSerialized]
        private bool _entered;
        [NonSerialized]
        private IDynamicContext<string> _dynamicContext;

        protected IDynamicContext<string> Context => _dynamicContext;

        public void Initialize()
        {
            OnInitialize();
        }

        public TaskStatus Tick(float dt)
        {
            if (!_entered)
            {
                _entered = true;
                OnEnter();
            }

            var status = OnTick(dt);

            switch (status)
            {
                case TaskStatus.Success:
                case TaskStatus.Failure:
                    OnExit();
                    Reset();
                    break;
                case TaskStatus.Running:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status));
            }

            return status;
        }

        public void Reset()
        {
            _entered = false;
            OnReset();
        }

        public virtual void SetContext(IDynamicContext<string> context)
        {
            _dynamicContext = context;
        }

        protected virtual void OnInitialize()
        {
        }
        
        protected virtual void OnEnter()
        {
        }

        protected abstract TaskStatus OnTick(float dt);

        protected virtual void OnExit()
        {
        }

        protected virtual void OnReset()
        {
        }
    }
}
