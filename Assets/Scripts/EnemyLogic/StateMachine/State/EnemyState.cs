using EnemyLogic.StateMachine.Transition;
using UnityEngine;

namespace EnemyLogic.StateMachine.State
{
    public class EnemyState : MonoBehaviour
    {
        [SerializeField] private EnemyTransition[] _transitions;

        public EnemyTarget EnemyTarget { get; private set; }

        public Animator Animator { get; private set; }

        public Transform Target { get; private set; }

        public EnemyTransition[] Transitions => _transitions;

        public void Enter(EnemyTarget enemyTarget, Animator animator, Transform target)
        {
            if (enabled == false)
            {
                EnemyTarget = enemyTarget;
                Animator = animator;
                Target = target;

                enabled = true;

                foreach (var transition in _transitions)
                {
                    transition.enabled = true;
                    transition.Init(EnemyTarget, Target);
                }
            }
        }

        public EnemyState GetNextState()
        {
            foreach (var transition in _transitions)
            {
                if (transition.NeedTransit)
                {
                    return transition.TargetState;
                }
            }

            return null;
        }

        public void Exit()
        {
            if (enabled == true)
            {
                foreach (var transition in _transitions)
                {
                    transition.enabled = false;
                }
            }

            enabled = false;
        }
    }
}