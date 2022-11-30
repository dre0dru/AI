using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.BehaviourTree.Tasks.Composite
{
    [Serializable]
    public abstract class ParallelSequenceTask : CompositeTask
    {
        [SerializeField]
        private bool _waitForCompletion;

        protected readonly Dictionary<ITask, TaskStatus> _childrenCompletionStatus;

        protected ParallelSequenceTask() : this(new List<ITask>())
        {
        }

        protected ParallelSequenceTask(List<ITask> children) : base(children)
        {
            _childrenCompletionStatus = new Dictionary<ITask, TaskStatus>();
        }

        protected override TaskStatus OnTick(float dt)
        {
            ProcessChildren(dt);

            if (_waitForCompletion)
            {
                if (_childrenCompletionStatus.Count == Count)
                {
                    return ProcessFullCompletion();
                }
            }
            else if (_childrenCompletionStatus.Count > 0)
            {
                if (TryProcessPartialCompletion(out var onTick))
                {
                    return onTick;
                }
            }

            return TaskStatus.Running;
        }

        private void ProcessChildren(float dt)
        {
            foreach (var child in _children)
            {
                if (!_childrenCompletionStatus.TryGetValue(child, out var status))
                {
                    status = child.Tick(dt);

                    if (status != TaskStatus.Running)
                    {
                        _childrenCompletionStatus.Add(child, status);
                    }
                }
            }
        }

        protected abstract TaskStatus ProcessFullCompletion();

        protected abstract bool TryProcessPartialCompletion(out TaskStatus resultStatus);

        protected override void OnReset()
        {
            base.OnReset();
            _childrenCompletionStatus.Clear();
        }
    }
}
