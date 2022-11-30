using Dre0Dru.Buildables;

namespace Dre0Dru.BehaviourTree.Builder
{
    public static partial class BuilderExtensions
    {
        public static Buildable<Buildable<TComposite>, TChild> AddChild<TComposite, TChild>(
            this Buildable<TComposite> buildable)
            where TComposite : ITask, ICompositeTask
            where TChild : ITask, new() =>
            buildable.AddChild(new TChild());

        public static Buildable<Buildable<TComposite>, TChild> AddChild<TComposite, TChild>(
            this Buildable<TComposite> buildable,
            TChild child)
            where TComposite : ITask, ICompositeTask
            where TChild : ITask
        {
            buildable.Unwrap().AddChild(child);

            return new Buildable<Buildable<TComposite>, TChild>(buildable, child);
        }
    }
}
