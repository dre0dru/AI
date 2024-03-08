using System;
using System.Collections.Generic;
using Dre0Dru.Collections;
using UnityEngine;
using UnityEngine.Scripting;

namespace Dre0Dru.Blackboard
{
    [Serializable]
    public class Blackboard<TKey> : IBlackboard<TKey>
    {
        [SerializeField]
        private UDictionary<TKey, IDynamicValue> _values;

        [RequiredMember]
        public Blackboard()
        {
            _values = new UDictionary<TKey, IDynamicValue>();
        }

        public Blackboard(IDictionary<TKey, IDynamicValue> values)
        {
            _values = new UDictionary<TKey, IDynamicValue>(values);
        }

        public void SetValue<TValue>(TKey key, TValue value)
            where TValue : class
        {
            if (!_values.TryGetValue(key, out var blackboardValue))
            {
                blackboardValue = DynamicValue<TValue>.New(value);
                _values[key] = blackboardValue;
            }
            
            _values[key].SetValue(value);
        }

        public TValue GetValue<TValue>(TKey key)
            where TValue : class =>
            _values[key].GetValue<TValue>();

        public bool HasValue<TValue>(TKey key)
            where TValue : class =>
            TryGetValue<TValue>(key, out _);

        public bool TryGetValue<TValue>(TKey key, out TValue value)
            where TValue : class
        {
            if (_values.TryGetValue(key, out var dynamicValue))
            {
                value = dynamicValue.GetValue<TValue>();
                return value != null;
            }

            value = default;
            return false;
        }

        public bool RemoveValue(TKey key) =>
            _values.Remove(key);
    }

    [Serializable]
    public class Blackboard : Blackboard<string>
    {
        
    }
}
