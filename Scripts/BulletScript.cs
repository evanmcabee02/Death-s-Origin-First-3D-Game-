using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
namespace OriginGame
{
    public class BulletScript : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                Destroy(gameObject);
                StatsScript.player.TakeDamage(1);
            }
        }
    }
}
