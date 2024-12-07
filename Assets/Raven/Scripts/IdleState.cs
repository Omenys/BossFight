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
            Debug.Log("I'm idle!");
            animator.SetBool("isIdle", true);
            animator.SetBool("isPursuing", false);
        }
        public override void EnterState()
        {
            Debug.Log("Start idle");
        }
        public override void ExitState()
        {
            Debug.Log("Stop idle");
            animator.SetBool("isIdle", false);
        }
    }
}
