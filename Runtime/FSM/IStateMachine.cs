namespace Dre0Dru.FSM
{
    //TODO split into Generic State Machine and Keyed State Machine?
    public interface IStateMachine
    {
        IState? CurrentState { get; }

        bool CanEnterState(IState state);

        bool TryEnterState(IState state);

        void ForceEnterState(IState state);
    }

    //TODO as composition of different interfaces?
    //TODO StateTransitions for data driven logic?
    public interface IStateMachine<TState>
    {
        TState? CurrentState { get; }

        bool CanSwitchState(TState state);

        bool TrySwitchState(TState state);

        void ForceSwitchState(TState state);
    }

    public interface IStateMachine<TState, in TContext>
    {
        TState? CurrentState { get; }

        bool CanSwitchState(TState state, TContext ctx);

        bool TrySwitchState(TState state, TContext ctx);

        void ForceSwitchState(TState state, TContext ctx);
    }
}
