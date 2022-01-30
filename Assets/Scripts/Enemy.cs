using UnityEngine;
using UnityEngine.AI;

namespace EITest.GameProcess.Players
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : MainGameProcess
    {
        NavMeshAgent agent;

        [SerializeField]
        private int healthEnemy;

        private Transform player;

        private int index = 1;

        private void Awake()
        {
            player = GameObject.Find("Player").transform;
            agent = GetComponent<NavMeshAgent>();
        }

        private void FixedUpdate()
        {
            ChasePlayer();

            if (healthEnemy <= 0)
                Kill(index);
        }

        private void ChasePlayer()
        {
            if (!isPaused)
                agent.SetDestination(player.position);
        }

        public void TakeDamage(int damage)
        {
            healthEnemy -= damage;
        }
    }
}
