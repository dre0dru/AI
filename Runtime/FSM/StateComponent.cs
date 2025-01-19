using UnityEngine;

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

    public class StateComponent<TContext> : MonoBehaviour, IState<TContext>
    {
        public virtual bool CanEnterState(TContext ctx)
        {
            return true;
        }

        public virtual bool CanExitState(TContext ctx)
        {
            return true;
        }

        public virtual void OnStateEntered(TContext ctx)
        {
            enabled = true;
        }

        public virtual void OnStateExited(TContext ctx)
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
