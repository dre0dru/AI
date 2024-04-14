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
    }

    [Serializable]
    public class State<TBaseState> : IState<TBaseState>
        where TBaseState : IState<TBaseState>
    {
        public virtual bool CanEnterState(TBaseState from)
        {
            return true;
        }

        public virtual bool CanExitState(TBaseState to)
        {
            return true;
        }

        public virtual void OnStateEntered(TBaseState from)
        {
        }

        public virtual void OnStateExited(TBaseState to)
        {
        }
    }
}
