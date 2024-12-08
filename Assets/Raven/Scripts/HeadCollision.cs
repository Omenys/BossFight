using UnityEngine;

namespace TheProblem
{
    public class HeadCollision : MonoBehaviour
    {
        private AttackState attackState;

        public void SetAttackState(AttackState state)
        {
            attackState = state;
        }

        // On collision with player, perform basic attack
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Basically attacked");
                attackState.BasicAttack();
            }
        }
    }
}
