using System;

namespace Dre0Dru.FSM
{
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
