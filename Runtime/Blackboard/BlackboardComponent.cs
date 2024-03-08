using UnityEngine;

namespace Dre0Dru.Blackboard
{
    public class BlackboardComponent<TKey> : MonoBehaviour, IBlackboard<TKey>
    {
        [SerializeField]
        private Blackboard<TKey> _blackboard;

        public void SetValue<TValue>(TKey key, TValue value)
            where TValue : class =>
            _blackboard.SetValue(key, value);

        public TValue GetValue<TValue>(TKey key)
            where TValue : class =>
            _blackboard.GetValue<TValue>(key);

        public bool HasValue<TValue>(TKey key)
            where TValue : class =>
            _blackboard.HasValue<TValue>(key);

        public bool TryGetValue<TValue>(TKey key, out TValue value)
            where TValue : class =>
            _blackboard.TryGetValue(key, out value);

        public bool RemoveValue(TKey key) =>
            _blackboard.RemoveValue(key);
    }

    public class BlackboardComponent : BlackboardComponent<string>
    {
    }
}
