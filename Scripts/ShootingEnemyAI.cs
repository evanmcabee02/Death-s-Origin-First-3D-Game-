using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace OriginGame
{
    public class ShootingEnemyAI : MonoBehaviour
    {

        public NavMeshAgent enemy;
        public Transform player;

        [SerializeField] private float timer = 5;
        private float bulletTime;

        public GameObject enemyBullet;
        public Transform spawnPoint;
        public float enemySpeed;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SetPlayer());
        }
        IEnumerator SetPlayer()
        {
            yield return new WaitForSeconds(0.1f);
            player = StatsScript.player.gameObject.transform;
        }


        // Update is called once per frame
        void Update()
        {
            if (player != null)
            {
                enemy.SetDestination(player.position);
                gameObject.transform.LookAt(player);
                ShootAtPlayer();
            }
        }

        void ShootAtPlayer()
        {
            bulletTime -= Time.deltaTime;

            if (bulletTime > 0)
            {
                return;
            }

            bulletTime = timer;
            GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
            Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
            bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);
            Destroy(bulletObj, 5f);
        }

    }
}