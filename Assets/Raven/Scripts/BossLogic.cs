using UnityEngine;
using UnityEngine.AI;

namespace TheProblem
{
    public class BossLogic : MonoBehaviour
    {
        public StateMachine myStateMachine;
        public NavMeshAgent agent;

        // Start is called before the first frame update
        void Start()
        {
            myStateMachine = new StateMachine();
            myStateMachine.Initialize(this, new IdleState(myStateMachine));
            agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            myStateMachine.Update();
        }
    }
}
