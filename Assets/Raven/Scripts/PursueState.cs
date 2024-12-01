using UnityEngine;

namespace TheProblem
{
    public class PursueState : State
    {
        public PursueState(StateMachine m) : base(m)
        {
        }
        public override void UpdateState()
        {
            Debug.Log("I'm pursuing");
        }
        public override void EnterState()
        {
            Debug.Log("Start pursuing");
        }
        public override void ExitState()
        {
            Debug.Log("Stop pursuing");
        }
    }
}
