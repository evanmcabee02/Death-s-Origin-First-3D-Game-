using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OriginGame
{
    public class EnemyStats : MonoBehaviour
    {
        public int health = 5;
        public int killscore = 0;
        public int damage = 1;
        // Start is called before the first frame update
        void Start()
        {
            killscore = health;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                StatsScript.player.TakeDamage(damage);
            }
        }
        public void TakeDamage(int dmg)
        {
            gameObject.GetComponent<AudioSource>().Play();
            health -= dmg;
            if (health <= 0)
            {
                StatsScript.player.kills += killscore;
                Destroy(this.gameObject);
            }
        }
    }
}