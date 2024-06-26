﻿using UnityEngine;

namespace Dre0Dru.FSM
{
    public class StateComponent : MonoBehaviour, IState
    {
        public virtual bool CanEnterState()
        {
            return true;
        }

        public virtual bool CanExitState()
        {
            return true;
        }

        public virtual void OnStateEntered()
        {
            enabled = true;
        }

        public virtual void OnStateExited()
        {
            enabled = false;
        }

        protected bool IsTypeOf<TState>()
        {
            return this is TState;
        }

        protected bool IsTypeOf<TState>(out TState? state)
        {
            if (this is TState casted)
            {
                state = casted;
                return true;
            }

            state = default;
            return false;
        }

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
            {
                return;
            }

            enabled = false;
        }
#endif
    }

    public class StateComponent<TBaseState> : MonoBehaviour, IState<TBaseState>
        where TBaseState : IState<TBaseState>
    {
        public virtual bool CanEnterState(TBaseState from)
        {
            return true;
        }

        public virtual bool CanExitState(TBaseState to)
        {
            return true;
        }

        public virtual void OnStateEntered(TBaseState from)
        {
            enabled = true;
        }

        public virtual void OnStateExited(TBaseState to)
        {
            enabled = false;
        }

        protected bool IsTypeOf<TState>()
        {
            return this is TState;
        }

        protected bool IsTypeOf<TState>(out TState? state)
        {
            if (this is TState casted)
            {
                state = casted;
                return true;
            }

            state = default;
            return false;
        }

        #if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
            {
                return;
            }

            enabled = false;
        }
        #endif
    }
}
