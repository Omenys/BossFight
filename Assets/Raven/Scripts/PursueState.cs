using UnityEngine;
using UnityEngine.AI;

namespace TheProblem
{
    public class PursueState : State
    {
        private NavMeshAgent agent;
        private Transform target;
        private Animator animator;
        private BossLogic boss;


        public PursueState(StateMachine m, NavMeshAgent agent, Transform target, Animator animator, BossLogic boss) : base(m)
        {
            this.agent = agent;
            this.target = target;
            this.animator = animator;
            this.boss = boss;
        }
        public override void UpdateState()
        {
            float distanceToTarget = Vector3.Distance(agent.transform.position, target.position);
            if (distanceToTarget <= boss.GetAttackRange())
            {
                agent.isStopped = true;
                agent.ResetPath();
                myStateMachine.ChangeState(new AttackState(myStateMachine, agent, target, animator, boss));
            }
            else
            {
                // Move to player's position
                agent.isStopped = false;
                agent.SetDestination(target.position);
            }

        }


        public override void EnterState()
        {
            if (agent != null)
            {
                // Can move
                agent.isStopped = false;

                animator.SetBool("isIdle", false);

                animator.SetBool("isPursuing", true);
            }
        }
        public override void ExitState()
        {
            if (agent != null)
            {
                // Stop moving
                agent.isStopped = true;

                animator.SetBool("isPursuing", false);

            }
        }
    }
}

