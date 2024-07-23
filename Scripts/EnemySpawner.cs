using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OriginGame
{
    public class EnemySpawner : MonoBehaviour
    {
        public Vector3[] spawnLocations;
        public GameObject[] prefabs;
        public int enemyHealth = 5;
        // Start is called before the first frame update
        void OnTriggerEnter(Collider other)
        {
            System.Random random = new System.Random();
            if (other.gameObject.tag == "Player")
            {
                foreach (Vector3 loc in spawnLocations)
                {
                    GameObject enemy = Instantiate(prefabs[random.Next(0, prefabs.Length)], loc, Quaternion.identity);
                    enemy.GetComponent<EnemyStats>().health = enemyHealth;
                }
                Destroy(this.gameObject);
            }
        }
    }
}