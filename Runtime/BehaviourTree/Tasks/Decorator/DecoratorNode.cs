namespace Dre0Dru.BehaviourTree.Tasks.Decorator
{
    //TODO wait until, condition w/ aborts, 
    public abstract class DecoratorNode : Node
    {
        private readonly INode _decorated;

        protected internal INode Decorated => _decorated;
        
        protected DecoratorNode(INode decorated)
        {
            _decorated = decorated;
        }
    }
}
