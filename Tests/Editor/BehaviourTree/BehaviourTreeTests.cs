using System.Collections;
using Dre0Dru.BehaviourTree;
using Dre0Dru.BehaviourTree;
using Dre0Dru.BehaviourTree;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Dre0Dru.BehaviourTree.Tests.Editor
{
    public class BehaviourTreeTests
    {
        [TestCase(NodeStatus.Success)]
        [TestCase(NodeStatus.Failure)]
        public void Node_Returns_CorrectStatus(NodeStatus returnStatus)
        {
            var node = new TestNode(returnStatus);

            Assert.AreEqual(false, node.IsStarted);
            Assert.AreEqual(0, node.StartCount);

            node.Tick(0);

            Assert.AreEqual(false, node.IsStarted);
            Assert.AreEqual(1, node.StartCount);
            Assert.AreEqual(returnStatus, node.Status);
        }

        [Test]
        public void Sequence_Returns_CorrectStatus_OnSuccess()
        {
            var node1 = new TestNode(NodeStatus.Success);
            var node2 = new TestNode(NodeStatus.Success);

            var sequence = new SequenceNode()
                .AddChild(node1)
                .AddChild(node2);

            for (int i = 0; i < sequence.Count; i++)
            {
                sequence.Tick(0);
            }

            Assert.AreEqual(NodeStatus.Success, node1.Status);
            Assert.AreEqual(NodeStatus.Success, node2.Status);
            Assert.AreEqual(1, sequence.StartCount);
            Assert.AreEqual(NodeStatus.Success, sequence.Status);
        }

        [Test]
        public void Sequence_Returns_CorrectStatus_OnFirstFailure()
        {
            var node1 = new TestNode(NodeStatus.Failure);
            var node2 = new TestNode(NodeStatus.Success);

            var sequence = new SequenceNode()
                .AddChild(node1)
                .AddChild(node2);

            sequence.Tick(0);

            Assert.AreEqual(NodeStatus.Failure, node1.Status);
            Assert.AreEqual(0, node2.StartCount);
            Assert.AreEqual(1, sequence.StartCount);
            Assert.AreEqual(NodeStatus.Failure, sequence.Status);
        }

        [Test]
        public void Sequence_Returns_CorrectStatus_OnSecondFailure()
        {
            var node1 = new TestNode(NodeStatus.Success);
            var node2 = new TestNode(NodeStatus.Failure);

            var sequence = new SequenceNode()
                .AddChild(node1)
                .AddChild(node2);

            for (int i = 0; i < sequence.Count; i++)
            {
                sequence.Tick(0);
            }

            Assert.AreEqual(NodeStatus.Success, node1.Status);
            Assert.AreEqual(NodeStatus.Failure, node2.Status);
            Assert.AreEqual(1, sequence.StartCount);
            Assert.AreEqual(NodeStatus.Failure, sequence.Status);
        }

        [Test]
        public void Selector_Stops_OnFirstChild_IfSuccess()
        {
            var node1 = new TestNode(NodeStatus.Success);
            var node2 = new TestNode(NodeStatus.Failure);

            var selector = new SelectorNode()
                .AddChild(node1)
                .AddChild(node2);

            selector.Tick(0);

            Assert.AreEqual(NodeStatus.Success, node1.Status);
            Assert.AreEqual(0, node2.StartCount);
            Assert.AreEqual(NodeStatus.Success, selector.Status);
        }

        [Test]
        public void Selector_Stops_OnSecondChild_IfFirstFails()
        {
            var node1 = new TestNode(NodeStatus.Failure);
            var node2 = new TestNode(NodeStatus.Success);

            var selector = new SelectorNode()
                .AddChild(node1)
                .AddChild(node2);

            selector.Tick(0);
            selector.Tick(0);

            Assert.AreEqual(NodeStatus.Failure, node1.Status);
            Assert.AreEqual(NodeStatus.Success, node2.Status);
            Assert.AreEqual(NodeStatus.Success, selector.Status);
        }

        [Test]
        public void RandomSelectorNode_PicksRandomChild_AndReturnsItsStatus()
        {
            var node1 = new TestNode(NodeStatus.Failure);
            var node2 = new TestNode(NodeStatus.Success);
            var node3 = new TestNode(NodeStatus.Failure);

            var randomSelector = new RandomSelectorNode();
            randomSelector
                .AddChild(node1)
                .AddChild(node2)
                .AddChild(node3);

            randomSelector.Tick(0);

            var randomChild = randomSelector.Children[randomSelector.RandomChildIndex] as Node;

            Assert.AreEqual(randomChild!.Status, randomSelector.Status);
            Assert.AreEqual(1, randomChild.StartCount);
        }
        
        [Test]
        public void ParallelSequenceNode_Fails_IfFirstChildFails()
        {
            var node1 = new TestNode(NodeStatus.Failure);
            var node2 = new TestNode(NodeStatus.Success);

            var parallelSequence = new ParallelSequenceNode()
                .AddChild(node1)
                .AddChild(node2);

            parallelSequence.Tick(0);

            Assert.AreEqual(NodeStatus.Failure, parallelSequence.Status);
            Assert.AreEqual(NodeStatus.Failure, node1.Status);
            Assert.AreEqual(0, node2.StartCount);
        }
        
        [Test]
        public void ParallelSequenceNode_Fails_IfSecondChildFails_AndFirstNodeIsAborted()
        {
            var node1 = new TestNode(NodeStatus.Running);
            var node2 = new TestNode(NodeStatus.Failure);

            var parallelSequence = new ParallelSequenceNode()
                .AddChild(node1)
                .AddChild(node2);

            parallelSequence.Tick(0);

            Assert.AreEqual(NodeStatus.Failure, parallelSequence.Status);
            Assert.AreEqual(NodeStatus.Failure, node1.Status);
            Assert.AreEqual(true, node1.WasAborted);
        }

        [Test]
        public void ParallelSequenceNode_Succeeds_IfAllChildrenSucceed()
        {
            var node1 = new TestNode(NodeStatus.Success);
            var node2 = new TestNode(NodeStatus.Success);

            var parallelSequence = new ParallelSequenceNode()
                .AddChild(node1)
                .AddChild(node2);

            parallelSequence.Tick(0);

            Assert.AreEqual(NodeStatus.Success, parallelSequence.Status);
            Assert.AreEqual(NodeStatus.Success, node1.Status);
            Assert.AreEqual(NodeStatus.Success, node2.Status);
        }
        
        [Test]
        public void InverterNode_Inverts_Success_To_Failure()
        {
            var decoratedNode = new TestNode(NodeStatus.Success);
            var inverterNode = new InverterNode(decoratedNode);

            var status = inverterNode.Tick(0);

            Assert.AreEqual(NodeStatus.Failure, status);
            Assert.AreEqual(1, decoratedNode.StartCount);
        }

        [Test]
        public void InverterNode_Inverts_Failure_To_Success()
        {
            var decoratedNode = new TestNode(NodeStatus.Failure);
            var inverterNode = new InverterNode(decoratedNode);

            var status = inverterNode.Tick(0);

            Assert.AreEqual(NodeStatus.Success, status);
            Assert.AreEqual(1, decoratedNode.StartCount);
        }

        [Test]
        public void InverterNode_Keeps_Running_Status()
        {
            var decoratedNode = new TestNode(NodeStatus.Running);
            var inverterNode = new InverterNode(decoratedNode);

            var status = inverterNode.Tick(0);

            Assert.AreEqual(NodeStatus.Running, status);
            Assert.AreEqual(1, decoratedNode.StartCount);
        }
        
        [Test]
        public void RepeaterNode_Repeats_DecoratedNode_GivenTimes_And_Succeeds()
        {
            var repeatCount = 3;
            var decoratedNode = new TestNode(NodeStatus.Success);
            var repeaterNode = new RepeaterNode(decoratedNode, repeatCount);

            NodeStatus status = NodeStatus.Running;
            for (int i = 0; i < repeatCount; i++)
            {
                status = repeaterNode.Tick(0);
                if (i < repeatCount - 1)
                {
                    Assert.AreEqual(NodeStatus.Running, status);
                }
            }

            Assert.AreEqual(NodeStatus.Success, status);
            Assert.AreEqual(repeatCount, decoratedNode.StartCount);
        }

        [Test]
        public void RepeaterNode_Stops_IfDecoratedNode_Fails()
        {
            var repeatCount = 3;
            var decoratedNode = new TestNode(NodeStatus.Failure);
            var repeaterNode = new RepeaterNode(decoratedNode, repeatCount);

            var status = repeaterNode.Tick(0);

            Assert.AreEqual(NodeStatus.Failure, status);
            Assert.AreEqual(1, decoratedNode.StartCount);
        }

        [Test]
        public void RepeaterNode_Continues_IfDecoratedNode_IsRunning()
        {
            var repeatCount = 3;
            var decoratedNode = new TestNode(NodeStatus.Running);
            var repeaterNode = new RepeaterNode(decoratedNode, repeatCount);

            var status = repeaterNode.Tick(0);

            Assert.AreEqual(NodeStatus.Running, status);
            Assert.AreEqual(1, decoratedNode.StartCount);
        }
    }
}
