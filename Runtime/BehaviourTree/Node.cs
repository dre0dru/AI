using System;
using System.Collections;
using System.Collections.Generic;
using Dre0Dru.Blackboard;
using UnityEngine;

namespace Dre0Dru.BehaviourTree
{
    [Serializable]
    public abstract class Node : INode
    {
        [SerializeField]
        private NodeStatus _status;
        [SerializeField]
        private bool _isStarted = false;
        [SerializeField]
        private bool _wasAborted = false;
        [SerializeField]
        private int _startCount = 0;

        private IBlackboard _blackboard;

        public NodeStatus Status => _status;

        public virtual IBlackboard Blackboard
        {
            get => _blackboard;
            set => _blackboard = value;
        }

        internal bool IsStarted => _isStarted;
        internal bool WasAborted => _wasAborted;
        internal int StartCount => _startCount;

        public NodeStatus Tick(float dt)
        {
            if (!_isStarted)
            {
                Start();
            }

            _status = OnTick(dt);

            switch (_status)
            {
                case NodeStatus.Success:
                case NodeStatus.Failure:
                    Stop();
                    break;
                case NodeStatus.Running:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_status), _status, string.Empty);
            }

            return _status;
        }

        public void Abort(NodeStatus abortStatus)
        {
            if (_status != NodeStatus.Running)
            {
                throw new ArgumentException($"Can't abort non-running node", nameof(abortStatus));
            }
            
            _status = abortStatus;
            _wasAborted = true;
            Stop();
        }

        protected virtual void OnStart()
        {
        }

        protected abstract NodeStatus OnTick(float dt);

        protected virtual void OnStop()
        {
        }

        private void Start()
        {
            _isStarted = true;
            _wasAborted = false;
            _startCount++;
            _status = NodeStatus.Running;
            OnStart();
        }

        private void Stop()
        {
            _isStarted = false;
            OnStop();
        }

        public abstract IEnumerator<INode> GetEnumerator();
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
