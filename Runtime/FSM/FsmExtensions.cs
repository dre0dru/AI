using System.Collections.Generic;

namespace Dre0Dru.FSM
{
    public static class FsmExtensions
    {
        public static bool TrySwitchStateIfNotCurrent<TState>(this IStateMachine<TState> stateMachine, TState state)
            where TState : class, IState<TState>
        {
            if (stateMachine.CurrentState == state)
            {
                return false;
            }

            return stateMachine.TrySwitchState(state);
        }

        public static bool TrySwitchStates<TState>(this IStateMachine<TState> stateMachine, IEnumerable<TState> states, out TState enteredState)
            where TState : class, IState<TState>
        {
            enteredState = default;
            
            foreach (var state in states)
            {
                if (stateMachine.TrySwitchState(state))
                {
                    enteredState = state;
                    return true;
                }
            }

            return false;
        }
        
        public static bool TrySwitchStatesIfNotCurrent<TState>(this IStateMachine<TState> stateMachine, IEnumerable<TState> states, out TState enteredState)
            where TState : class, IState<TState>
        {
            enteredState = default;
            
            foreach (var state in states)
            {
                if (stateMachine.TrySwitchStateIfNotCurrent(state))
                {
                    enteredState = state;
                    return true;
                }
            }

            return false;
        }
    }
}
