using UnityEngine;
using UnityEngine.AI;

namespace TheProblem
{
    public class BossLogic : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] float sightRange = 10f;
        [SerializeField] float attackRange = 5f;
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

            // If player is in line of sight, change state to pursue
            if (LineOfSight() && myStateMachine.currentState is not PursueState)
            {
                myStateMachine.ChangeState(new PursueState(myStateMachine, agent, target));
            }

            // If player is not in sight, return to idle state
            else if (!LineOfSight() && myStateMachine.currentState is not IdleState)
            {
                myStateMachine.ChangeState(new IdleState(myStateMachine));
            }
        }


        // Check if player is in line of sight
        bool LineOfSight()
        {
            // Get direction from the boss to the player
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            // If player is outside range, it is out of sight
            if (distanceToTarget > sightRange)
            {
                return false;
            }

            // Dot product
            float dot = Vector3.Dot(transform.forward, directionToTarget);

            // Raycast
            Ray ray = new Ray(transform.position, directionToTarget);
            if (Physics.Raycast(ray, out RaycastHit hit, sightRange))
            {
                Debug.DrawRay(transform.position, directionToTarget * sightRange, Color.red);

                // If raycast hits target, it is in sight
                if (hit.transform == target)
                {
                    Debug.Log("Player sighted!");
                    return true;
                }
            }
            return false;
        }
    }
}
