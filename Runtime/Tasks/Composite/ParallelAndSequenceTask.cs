using System;
using System.Collections.Generic;

namespace Dre0Dru.BehaviourTree.Tasks.Composite
{
    [Serializable, AddTypeMenu("Composite/Parallel AND Sequence")]
    public class ParallelAndSequenceTask : ParallelSequenceTask
    {
        public ParallelAndSequenceTask()
        {
        }

        public ParallelAndSequenceTask(List<ITask> children) : base(children)
        {
        }

        protected override TaskStatus ProcessFullCompletion()
        {
            foreach (var status in _childrenCompletionStatus.Values)
            {
                if (status == TaskStatus.Failure)
                {
                    return TaskStatus.Failure;
                }
            }

            return TaskStatus.Success;
        }

        protected override bool TryProcessPartialCompletion(out TaskStatus resultStatus)
        {
            foreach (var status in _childrenCompletionStatus.Values)
            {
                if (status == TaskStatus.Failure)
                {
                    resultStatus = TaskStatus.Failure;
                    return true;
                }
            }

            if (_childrenCompletionStatus.Count == Count)
            {
                resultStatus = TaskStatus.Success;
                return true;
            }

            resultStatus = TaskStatus.Running;
            return false;
        }
    }
}
