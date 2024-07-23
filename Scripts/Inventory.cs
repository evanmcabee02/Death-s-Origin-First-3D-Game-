using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OriginGame
{

    public class Inventory : MonoBehaviour
    {
        public bool isPlayer = false;
        public static Inventory playerInventory = null;
        void Start()
        {
            if (isPlayer)
            {
                playerInventory = this;
            }
        }
        public List<Item> Items = new List<Item>();
    }
}