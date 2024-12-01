using UnityEngine;

namespace TheProblem
{
    public class AttackState : State
    {
        public AttackState(StateMachine m) : base(m)
        {
        }
        public override void UpdateState()
        {
            Debug.Log("I'm attacking");
        }
        public override void EnterState()
        {
            Debug.Log("Start attacking");
        }
        public override void ExitState()
        {
            Debug.Log("Stop attacking");
        }
    }
}
