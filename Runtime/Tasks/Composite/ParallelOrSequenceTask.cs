using System;
using System.Collections.Generic;

namespace Dre0Dru.BehaviourTree.Tasks.Composite
{
    [Serializable, AddTypeMenu("Composite/Parallel OR Sequence")]
    public class ParallelOrSequenceTask : ParallelSequenceTask
    {
        public ParallelOrSequenceTask()
        {
        }

        public ParallelOrSequenceTask(List<ITask> children) : base(children)
        {
        }

        protected override TaskStatus ProcessFullCompletion()
        {
            foreach (var status in _childrenCompletionStatus.Values)
            {
                if (status == TaskStatus.Success)
                {
                    return TaskStatus.Success;
                }
            }

            return TaskStatus.Failure;
        }

        protected override bool TryProcessPartialCompletion(out TaskStatus resultStatus)
        {
            foreach (var status in _childrenCompletionStatus.Values)
            {
                if (status == TaskStatus.Success)
                {
                    resultStatus = TaskStatus.Success;
                    return true;
                }
            }

            if (_childrenCompletionStatus.Count == Count)
            {
                resultStatus = TaskStatus.Failure;
                return true;
            }

            resultStatus = TaskStatus.Running;
            return false;
        }
    }
}
