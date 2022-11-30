using System;
using System.Collections.Generic;
using Dre0Dru.DynamicContext;
using UnityEngine;

namespace Dre0Dru.BehaviourTree.Tasks.Composite
{
    [Serializable]
    public abstract class CompositeTask : TaskBase, ICompositeTask
    {
        [SerializeReference, SubclassSelector]
        protected List<ITask> _children;

        protected int Count => _children.Count;

        protected CompositeTask() : this(new List<ITask>())
        {
        }

        protected CompositeTask(List<ITask> children)
        {
            _children = children;
        }

        public void AddChild<TNode>(TNode child)
            where TNode : ITask
        {
            _children.Add(child);
        }

        protected override void OnInitialize()
        {
            foreach (var child in _children)
            {
                child.Initialize();
            }
        }

        protected override void OnReset()
        {
            foreach (var child in _children)
            {
                child.Reset();
            }
        }
        
        public override void SetContext(IDynamicContext<string> context)
        {
            base.SetContext(context);
            foreach (var child in _children)
            {
                child.SetContext(context);
            }
        }
    }
}
