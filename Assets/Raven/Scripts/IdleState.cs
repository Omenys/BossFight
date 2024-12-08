using UnityEngine;

namespace TheProblem
{
    public class IdleState : State
    {
        private Animator animator;

        public IdleState(StateMachine m, Animator animator) : base(m)
        {
            this.animator = animator;
        }
        public override void UpdateState()
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isPursuing", false);
        }
        public override void EnterState()
        {

        }
        public override void ExitState()
        {
            animator.SetBool("isIdle", false);
        }
    }
}
