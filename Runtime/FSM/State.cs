using System;

namespace Dre0Dru.FSM
{
    [Serializable]
    public class State : IState
    {
        public virtual bool CanEnterState()
        {
            return true;
        }

        public virtual bool CanExitState()
        {
            return true;
        }

        public virtual void OnStateEntered()
        {
        }

        public virtual void OnStateExited()
        {
        }

        protected bool IsTypeOf<TState>()
        {
            return this is TState;
        }

        protected bool IsTypeOf<TState>(out TState? state)
        {
            if (this is TState casted)
            {
                state = casted;
                return true;
            }

            state = default;
            return false;
        }
    }

    [Serializable]
    public class State<TContext> : IState<TContext>
    {
        public virtual bool CanEnterState(TContext ctx)
        {
            return true;
        }

        public virtual bool CanExitState(TContext ctx)
        {
            return true;
        }

        public virtual void OnStateEntered(TContext ctx)
        {
        }

        public virtual void OnStateExited(TContext ctx)
        {
        }

        protected bool IsTypeOf<TState>()
        {
            return this is TState;
        }

        protected bool IsTypeOf<TState>(out TState? state)
        {
            if (this is TState casted)
            {
                state = casted;
                return true;
            }

            state = default;
            return false;
        }
    }
}
