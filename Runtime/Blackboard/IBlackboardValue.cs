namespace Dre0Dru.Blackboard
{
    public interface IBlackboardValue
    {
        TValue GetValue<TValue>()
            where TValue : class;

        void SetValue<TValue>(TValue value)
            where TValue : class;
    }
}
