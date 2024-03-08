using Dre0Dru.Values;

namespace Dre0Dru.Blackboard
{
    public static class BlackboardExtensions
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

        public static void SetValue<TValue>(this IBlackboard<string> blackboard, TValue value)
            where TValue : class =>
            blackboard.SetValue(GetStringKey<TValue>(), value);

        public static TValue GetValue<TValue>(this IBlackboard<string> blackboard)
            where TValue : class =>
            blackboard.GetValue<TValue>(GetStringKey<TValue>());

        public static bool HasValue<TValue>(this IBlackboard<string> blackboard)
            where TValue : class =>
            blackboard.HasValue<TValue>(GetStringKey<TValue>());

        public static bool TryGetValue<TValue>(this IBlackboard<string> blackboard, out TValue value)
            where TValue : class =>
            blackboard.TryGetValue<TValue>(GetStringKey<TValue>(), out value);

        public static bool RemoveValue<TValue>(this IBlackboard<string> blackboard) =>
            blackboard.RemoveValue(GetStringKey<TValue>());

        private static string GetStringKey<TValue>() => typeof(TValue).FullName;
    }
}
