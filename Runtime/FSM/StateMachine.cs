using System;

namespace Dre0Dru.FSM
{
    [Serializable]
    public class StateMachine : IStateMachine
    {
        private IState _currentState;

        public IState CurrentState => _currentState;

        public virtual bool CanEnterState(IState state)
        {
            ThrowIfNull(state);

            return (_currentState == null || _currentState.CanExitState()) &&
                   state.CanEnterState();
        }

        public virtual bool TryEnterState(IState state)
        {
            ThrowIfNull(state);

            if (!CanEnterState(state))
            {
                return false;
            }

            ForceEnterState(state);
            return true;
        }

        public virtual void ForceEnterState(IState state)
        {
            ThrowIfNull(state);

            var previousState = _currentState;
            previousState?.OnStateExited();

            _currentState = state;
            _currentState.OnStateEntered();
        }

        private void ThrowIfNull(IState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
        }
    }

    [Serializable]
    public class StateMachine<TBaseState> : IStateMachine<TBaseState>
        where TBaseState : IState<TBaseState>
    {
        private TBaseState _currentState;

        public TBaseState CurrentState => _currentState;

        public virtual bool CanSwitchState<TState>(TState state)
            where TState : TBaseState
        {
            ThrowIfNull(state);

            return (_currentState == null || _currentState.CanExitState(state)) &&
                   state.CanEnterState(_currentState);
        }

        public virtual bool TrySwitchState<TState>(TState state)
            where TState : TBaseState
        {
            ThrowIfNull(state);

            if (!CanSwitchState(state))
            {
                return false;
            }

            ForceSwitchState(state);
            return true;
        }

        public virtual void ForceSwitchState<TState>(TState state)
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
}
