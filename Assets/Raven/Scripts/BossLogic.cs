using UnityEngine;
using UnityEngine.AI;

namespace TheProblem
{
    public class BossLogic : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] Animator animator;
        [SerializeField] float sightRange = 10f;
        [SerializeField] float attackRange = 4f;

        public StateMachine myStateMachine;
        public NavMeshAgent agent;


        public float GetAttackRange()
        {
            return attackRange;
        }


        // Start is called before the first frame update
        void Start()
        {
            myStateMachine = new StateMachine();
            myStateMachine.Initialize(this, new IdleState(myStateMachine, animator));
            agent = GetComponent<NavMeshAgent>();

        }

        // Update is called once per frame
        void Update()
        {
            myStateMachine.Update();

            // Cache line of sight
            bool playerInSight = LineOfSight();

            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            // If player is in line of sight and attack range, change state to attack
            if (playerInSight && distanceToTarget <= attackRange && myStateMachine.currentState is not AttackState)
            {
                Debug.Log("SWAPPING TO ATTACK STATE");
                myStateMachine.ChangeState(new AttackState(myStateMachine, agent, target, animator, this));
            }

            // If player is in line of sight, change state to pursue
            if (playerInSight && distanceToTarget > attackRange && myStateMachine.currentState is not PursueState)
            {
                myStateMachine.ChangeState(new PursueState(myStateMachine, agent, target, animator, this));

            }

            // If player is not in sight, return to idle state
            else if (!playerInSight && myStateMachine.currentState is not IdleState)
            {
                myStateMachine.ChangeState(new IdleState(myStateMachine, animator));

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
