namespace Dre0Dru.Blackboard
{
    public static partial class BlackboardExtensions
    {
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
