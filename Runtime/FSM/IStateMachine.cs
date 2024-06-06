namespace Dre0Dru.FSM
{
    //TODO split into Generic State Machine and Keyed State Machine?
    public interface IStateMachine
    {
        IState CurrentState { get; }

        bool CanEnterState(IState state);

        bool TryEnterState(IState state);

        void ForceEnterState(IState state);
    }

    //TODO as composition of different interfaces?
    //TODO StateTransitions for data driven logic?
    public interface IStateMachine<TBaseState>
    {
        TBaseState CurrentState { get; }

        bool CanEnterState<TState>(TState state)
            where TState : TBaseState;

        bool TryEnterState<TState>(TState state)
            where TState : TBaseState;

        void ForceEnterState<TState>(TState state)
            where TState : TBaseState;
    }
}
