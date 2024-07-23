using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OriginGame
{
    public class SaveState : MonoBehaviour
    {
        public static SaveState save;
        public int maxHealth = 6;
        public int damage = 2;
        public int lvlpoints = 0;
        // Start is called before the first frame update
        void Start()
        {
            if (save == null)
            {
                save = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }
    }
}