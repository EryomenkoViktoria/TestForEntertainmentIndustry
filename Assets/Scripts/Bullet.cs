using EITest.GameProcess.Players;
using UnityEngine;

namespace EITest.GameProcess.Weapon
{
    [RequireComponent(typeof(SphereCollider))]  
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private float speedBullet;
        [SerializeField]
        private int lifeTime;
        [SerializeField]
        private int damage;

        private void Start()
        {
            Invoke("DestroyBullet", lifeTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var players = collision.collider.gameObject;

            if (collision.collider.tag == "Enemy")
                players.GetComponent<Enemy>().TakeDamage(damage);

            if (collision.collider.tag == "Player")
                 players.GetComponent<Player>().TakeDamage(damage);
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * speedBullet * Time.deltaTime);
        }

        private void DestroyBullet()
        {
            Destroy(gameObject);
        }
    }
}