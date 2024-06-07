using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.FSM
{
    public class KeyedStatesCollectionComponent<TKey, TState> : MonoBehaviour
        where TState : IKeyedState<TKey>
    {
        private readonly Dictionary<TKey, TState> _states = new();

        public TState this[TKey key] => _states[key];

        public bool TryAddState(TState state)
        {
            return _states.TryAdd(state.Key, state);
        }

        public bool RemoveState(TKey key)
        {
            return _states.Remove(key);
        }

        public bool RemoveState(TState state)
        {
            return _states.Remove(state.Key);
        }

        public bool TryGetState(TKey key, out TState state)
        {
            return _states.TryGetValue(key, out state);
        }
    }
}
