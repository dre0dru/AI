namespace Dre0Dru.Blackboard
{
    //TODO bb merge: merge two diff bb values into one
    //TODO generic typed bb which allows to search by subtype/implementation
    //TODO keyless/typed bb
    public interface IBlackboard<in TKey>
    {
        void SetValue<TValue>(TKey key, TValue value)
            where TValue : class;
        
        TValue GetValue<TValue>(TKey key)
            where TValue : class;

        bool HasValue<TValue>(TKey key)
            where TValue : class;

        bool TryGetValue<TValue>(TKey key, out TValue value)
            where TValue : class;

        bool RemoveValue(TKey key);
    }
}
