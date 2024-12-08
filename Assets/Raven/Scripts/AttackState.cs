using UnityEngine;
using UnityEngine.AI;

namespace TheProblem
{
    public class AttackState : State
    {
        private NavMeshAgent agent;
        private Transform target;
        private Animator animator;
        private BossLogic boss;

        public AttackState(StateMachine m, NavMeshAgent agent, Transform target, Animator animator, BossLogic boss) : base(m)
        {
            this.agent = agent;
            this.target = target;
            this.animator = animator;
            this.boss = boss;
        }
        public override void UpdateState()
        {
            Debug.Log("HELLO ATTACK UPDATED");

            // Distance to player
            float distanceToTarget = Vector3.Distance(agent.transform.position, target.position);

            if (distanceToTarget > boss.GetAttackRange())
            {
                Debug.Log("Player out of attack range");
                myStateMachine.ChangeState(new PursueState(myStateMachine, agent, target, animator, boss));
                return;
            }

            // Start attack animation
            Debug.Log("Attacking the player");
            animator.SetTrigger("BasicAttack");

        }

        public override void EnterState()
        {
            Debug.Log("Enter Attack State");

            if (agent != null)
            {
                // Stop movement
                agent.isStopped = true;
                agent.ResetPath();
            }
            // Stop pursue animation
            animator.SetBool("isPursuing", false);

        }
        public override void ExitState()
        {
            Debug.Log("Exit Attack State");

        }
    }
}
