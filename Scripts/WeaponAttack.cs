using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OriginGame
{
    public class WeaponAttack : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.GetComponent<EnemyStats>().TakeDamage(SaveState.save.damage);
            }

        }
    }
}