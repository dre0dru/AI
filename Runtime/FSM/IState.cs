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
    public interface IState<in TContext>
    {
        bool CanEnterState(TContext ctx);

        bool CanExitState(TContext ctx);

        void OnStateEntered(TContext ctx);

        void OnStateExited(TContext ctx);
    }

    public interface IKeyedState<out TKey>
    {
        TKey Key { get; }
    }

    public interface IPriorityState
    {
        int Priority { get; }
    }

    public interface IReenterableState
    {
        bool CanReenterSelf();
    }

    public interface IReenterableState<in TContext>
    {
        bool CanReenterSelf(TContext ctx);
    }

    public interface IUpdatableState
    {
        void OnUpdate(float dt);
    }

    public interface IUpdatableState<in TContext>
    {
        void OnUpdate(TContext cxt, float dt);
    }
}
