using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace OriginGame
{

    public class EnemyFollowAI : MonoBehaviour
    {

        public NavMeshAgent enemy;
        public Transform player;
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
                enemy.SetDestination(player.position);
        }
    }

}