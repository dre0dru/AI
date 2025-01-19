using System;
using UnityEngine;

namespace Dre0Dru.FSM
{
    public class StateMachineComponent : MonoBehaviour, IStateMachine
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

    public class StateMachineComponent<TState> : MonoBehaviour, IStateMachine<TState>
        where TState : IState<TState>
    {
        private TState _currentState;

        public TState CurrentState => _currentState;

        public virtual bool CanSwitchState(TState state)
        {
            ThrowIfNull(state);

            return (_currentState == null || _currentState.CanExitState(state)) &&
                   state.CanEnterState(_currentState);
        }

        public virtual bool TrySwitchState(TState state)
        {
            ThrowIfNull(state);

            if (!CanSwitchState(state))
            {
                return false;
            }

            ForceSwitchState(state);
            return true;
        }

        public virtual void ForceSwitchState(TState state)
        {
            ThrowIfNull(state);

            var previousState = _currentState;
            previousState?.OnStateExited(state);

            _currentState = state;
            _currentState.OnStateEntered(previousState);
        }

        protected void ThrowIfNull(TState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
        }
    }

    public class StateMachineComponent<TState, TContext> : MonoBehaviour, IStateMachine<TState, TContext>
        where TState : IState<TContext>
    {
        private TState _currentState;

        public TState CurrentState => _currentState;

        public virtual bool CanSwitchState(TState state, TContext ctx)
        {
            ThrowIfNull(state);

            return (_currentState == null || _currentState.CanExitState(ctx)) &&
                   state.CanEnterState(ctx);
        }

        public virtual bool TrySwitchState(TState state, TContext ctx)
        {
            ThrowIfNull(state);

            if (!CanSwitchState(state, ctx))
            {
                return false;
            }

            ForceSwitchState(state, ctx);
            return true;
        }

        public virtual void ForceSwitchState(TState state, TContext ctx)
        {
            ThrowIfNull(state);

            var previousState = _currentState;
            previousState?.OnStateExited(ctx);

            _currentState = state;
            _currentState.OnStateEntered(ctx);
        }

        protected void ThrowIfNull(TState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
        }
    }
}
