using UnityEngine;

namespace TheProblem
{
    public class IdleState : State
    {
        public IdleState(StateMachine m) : base(m)
        {
        }
        public override void UpdateState()
        {
            Debug.Log("I'm idle!");
        }
        public override void EnterState()
        {
            Debug.Log("Start idle");
        }
        public override void ExitState()
        {
            Debug.Log("Stop idle");
        }
    }
}
