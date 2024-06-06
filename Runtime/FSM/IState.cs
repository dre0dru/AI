namespace Dre0Dru.FSM
{
    public interface IState
    {
        bool CanEnterState();

        bool CanExitState();

        void OnStateEntered();

        void OnStateExited();
    }

    //TODO as composition of different interfaces?
    public interface IState<in TState>
        where TState : IState<TState>
    {
        bool CanEnterState(TState from);

        bool CanExitState(TState to);

        void OnStateEntered(TState from);

        void OnStateExited(TState to);
    }

    public interface IKeyedState<out TKey>
    {
        TKey Key { get; }
    }

    public interface IPriorityState
    {
        int Priority { get; }
    }
}
