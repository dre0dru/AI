using System;
using System.Collections.Generic;

namespace Dre0Dru.BehaviourTree.Tasks.Leaf
{
    [Serializable]
    public abstract class LeafNode : Node
    {
        public override IEnumerator<INode> GetEnumerator()
        {
            yield break;
        }
    }
}
