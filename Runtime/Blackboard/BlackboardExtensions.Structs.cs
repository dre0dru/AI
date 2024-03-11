#if DRE0DRU_COLLECTIONS

using Dre0Dru.Collections;

namespace Dre0Dru.Blackboard
{
    public static partial class BlackboardExtensions
    {
        public static void SetValue<TKey, TValue>(this IBlackboard<TKey> blackboard,
            TKey key, TValue value)
            where TValue : struct
        {
            if (!blackboard.TryGetValue<ReferenceValue<TValue>>(key, out var blackboardValue))
            {
                blackboardValue = new ReferenceValue<TValue>(value);
                blackboard.SetValue(key, blackboardValue);
                return;
            }

            blackboardValue.Value = value;
        }

        public static TValue GetValue<TKey, TValue>(this IBlackboard<TKey> blackboard,
            TKey key)
            where TValue : struct =>
            blackboard.GetValue<ReferenceValue<TValue>>(key);

        public static bool HasValue<TKey, TValue>(this IBlackboard<TKey> blackboard,
            TKey key)
            where TValue : struct =>
            blackboard.HasValue<ReferenceValue<TValue>>(key);

        public static bool TryGetValue<TKey, TValue>(this IBlackboard<TKey> blackboard,
            TKey key, out TValue value)
            where TValue : struct
        {
            if (blackboard.TryGetValue(key, out ReferenceValue<TValue> boxedValue))
            {
                value = boxedValue;
                return true;
            }

            value = default;
            return false;
        }
    }
}

#endif
