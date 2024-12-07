using UnityEngine;
using UnityEngine.AI;

namespace TheProblem
{
    public class PursueState : State
    {
        private NavMeshAgent agent;
        private Transform target;
        private Animator animator;


        public PursueState(StateMachine m, NavMeshAgent agent, Transform target, Animator animator) : base(m)
        {
            this.agent = agent;
            this.target = target;
            this.animator = animator;
        }
        public override void UpdateState()
        {
            Debug.Log("I'm pursuing");
            if (agent != null && target != null)
            {
                // Move to player's position
                agent.SetDestination(target.position);

            }

        }

        public override void EnterState()
        {
            Debug.Log("Start pursuing");
            if (agent != null && target != null)
            {
                // Can move
                agent.isStopped = false;
                animator.SetBool("isIdle", false);
                animator.SetBool("isPursuing", true);
            }
        }
        public override void ExitState()
        {
            Debug.Log("Stop pursuing");
            if (agent != null)
            {
                // Stop moving towards player
                agent.isStopped = true;
                animator.SetBool("isPursuing", false);

            }
        }
    }
}

