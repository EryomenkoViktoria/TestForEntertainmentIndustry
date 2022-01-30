using UnityEngine;

namespace EITest.GameProcess.Players
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MainGameProcess
    {
        [SerializeField]
        private int healthPlayer;

        [SerializeField]
        private float speed;

        private Rigidbody rb;

        private int index = 2;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            rb.velocity = Vector3.zero;

            if (Input.GetKey(KeyCode.A))
                rb.velocity += Vector3.left * speed;
            if (Input.GetKey(KeyCode.D))
                rb.velocity += Vector3.right * speed;
            if (Input.GetKey(KeyCode.W))
                rb.velocity += Vector3.forward * speed;
            if (Input.GetKey(KeyCode.S))
                rb.velocity += Vector3.back * speed;

            if (healthPlayer <= 0)
                Kill(index);
        }

        public void TakeDamage(int damage)
        {
            healthPlayer =- damage;
        }
    }
}