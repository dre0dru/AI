using System;
using UnityEngine;

namespace Dre0Dru.Blackboard
{
    [Serializable]
    public class BlackboardValue<TActual> : IBlackboardValue
        where TActual : class
    {
        public static BlackboardValue<TActual> New(TActual value) =>
            new BlackboardValue<TActual>()
            {
                _value = value
            };

        [SerializeField]
        private TActual _value;

        public TValue GetValue<TValue>()
            where TValue : class =>
            _value as TValue;

        public void SetValue<TValue>(TValue value)
            where TValue : class =>
            _value = value as TActual;

        public static implicit operator TActual(BlackboardValue<TActual> value) =>
            value._value;

        public static implicit operator BlackboardValue<TActual>(TActual value) =>
            New(value);
    }
}
