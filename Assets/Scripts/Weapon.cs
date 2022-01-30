using EITest.GameProcess.Players;
using UnityEngine;

namespace EITest.GameProcess.Weapon
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefabBullet;

        [SerializeField]
        private Transform shootPoint;

        [SerializeField]
        private float shootDelay;

        [SerializeField]
        private float newShootDelay;

        [SerializeField]
        private Player player;

        [SerializeField]
        private Vector3 difference;

        [SerializeField]
        private float rotateY;

        [SerializeField]
        private GunType gunType;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        private Vector3 mousePosition;

        private void Update()
        {
            if (gunType == GunType.Player)
                PlayerTurn();

            else if (gunType == GunType.Enemy)
                EnemyTurn();

            if ((shootDelay <= 0) && (Input.GetMouseButton(0) || gunType == GunType.Enemy))
                Shoot();

            else
                shootDelay -= Time.deltaTime;
        }

        private void PlayerTurn()
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 difference = mousePosition - transform.position;
            difference.Normalize();
            float rotation_y = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, rotation_y, 0f);
        }

        private void EnemyTurn()
        {
            difference = player.transform.position - transform.position;
            rotateY = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, rotateY, 0f);
        }

        private void Shoot()
        {
            Instantiate(prefabBullet, shootPoint.position, shootPoint.rotation);
            shootDelay = newShootDelay;
        }
    }
}