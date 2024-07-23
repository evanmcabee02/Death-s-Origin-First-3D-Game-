using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OriginGame
{

    public class Item : MonoBehaviour
    {
        public string iName = "";
        public void FixedUpdate()
        {
            transform.Rotate(new Vector3(0, 2, 0), Space.World);
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Inventory.playerInventory.Items.Add(this);
                gameObject.SetActive(false);
            }
        }
    }
}