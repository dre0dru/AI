namespace Dre0Dru.BehaviourTree.Tests.Editor
{
    public class TestNode : Node
    {
        private readonly NodeStatus _returnStatus;

        public TestNode(NodeStatus returnStatus)
        {
            _returnStatus = returnStatus;
        }

        protected override NodeStatus OnTick(float dt)
        {
            return _returnStatus;
        }
    }
}
