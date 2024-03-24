using System;
using UnityEngine;

namespace Dre0Dru.FSM
{
    [Serializable]
    public class StateMachine<TBaseState> : IStateMachine<TBaseState>
        where TBaseState : IState<TBaseState>
    {
        [SerializeReference]
        private TBaseState _currentState;

        public TBaseState CurrentState => _currentState;


        public virtual bool CanEnterState<TState>(TState state)
            where TState : TBaseState
        {
            ThrowIfNull(state);

            return (_currentState == null || _currentState.CanExitState(state)) &&
                   state.CanEnterState(_currentState);
        }

        public virtual bool TryEnterState<TState>(TState state)
            where TState : TBaseState
        {
            ThrowIfNull(state);

            if (!CanEnterState(state))
            {
                return false;
            }

            ForceEnterState(state);
            return true;
        }

        public virtual void ForceEnterState<TState>(TState state)
            where TState : TBaseState
        {
            ThrowIfNull(state);

            var previousState = _currentState;
            previousState?.OnStateExited(state);

            _currentState = state;
            _currentState.OnStateEntered(previousState);
        }

        private void ThrowIfNull(TBaseState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
        }
    }

    [Serializable]
    public class StateMachine : StateMachine<IState>
    {
    }
}
