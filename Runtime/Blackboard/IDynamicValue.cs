namespace Dre0Dru.Blackboard
{
    //TODO IBlackboardValue?
    public interface IDynamicValue
    {
        TValue GetValue<TValue>()
            where TValue : class;

        void SetValue<TValue>(TValue value)
            where TValue : class;
    }
}
