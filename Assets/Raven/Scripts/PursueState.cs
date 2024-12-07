using UnityEngine;
using UnityEngine.AI;

namespace TheProblem
{
    public class PursueState : State
    {
        private NavMeshAgent agent;
        private Transform target;


        public PursueState(StateMachine m, NavMeshAgent agent, Transform target) : base(m)
        {
            this.agent = agent;
            this.target = target;
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
            }
        }
        public override void ExitState()
        {
            Debug.Log("Stop pursuing");
            if (agent != null)
            {
                // Stop moving towards player
                agent.isStopped = true;
            }
        }
    }
}

