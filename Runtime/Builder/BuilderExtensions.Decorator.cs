using Dre0Dru.Buildables;

namespace Dre0Dru.BehaviourTree.Builder
{
    public static partial class BuilderExtensions
    {
        public static Buildable<Buildable<TDecorator>, TDecorated> SetDecorated<TDecorator, TDecorated>(
            this Buildable<TDecorator> buildable)
            where TDecorator : ITask, IDecoratorTask
            where TDecorated : ITask, new() =>
            buildable.SetDecorated(new TDecorated());

        public static Buildable<Buildable<TDecorator>, TDecorated> SetDecorated<TDecorator, TDecorated>(
            this Buildable<TDecorator> builder, TDecorated buildable)
            where TDecorator : ITask, IDecoratorTask
            where TDecorated : ITask
        {
            builder.Unwrap().SetDecorated(buildable);

            return new Buildable<Buildable<TDecorator>, TDecorated>(builder, buildable);
        }
    }
}
