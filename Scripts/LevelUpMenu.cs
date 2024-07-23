using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
namespace OriginGame
{
    public class LevelUpMenu : MonoBehaviour
    {
        // Start is called before the first frame update
        public TMP_Text points;
        public TMP_Text health;
        public TMP_Text dmg;

        void Start()
        {
            health.text = "" + SaveState.save.maxHealth;
            dmg.text = "" + SaveState.save.damage;
            points.text = "Point: " + SaveState.save.lvlpoints + "\nNeeded: " + Mathf.Floor(10 * Mathf.Pow(1.25f, (SaveState.save.maxHealth + SaveState.save.damage - 7)));
        }
        public void lvlHealth()
        {
            Debug.Log(Mathf.Floor(10 * Mathf.Pow(1.25f, (SaveState.save.maxHealth + SaveState.save.damage - 7))));
            if (SaveState.save.lvlpoints > Mathf.Floor(10 * Mathf.Pow(1.25f, (SaveState.save.maxHealth + SaveState.save.damage - 7))))
            {
                SaveState.save.lvlpoints -= (int)(Mathf.Floor(10 * Mathf.Pow(1.25f, (SaveState.save.maxHealth + SaveState.save.damage - 7))));
                SaveState.save.maxHealth++;
                health.text = "" + SaveState.save.maxHealth;
                points.text = "Point: " + SaveState.save.lvlpoints + "\nNeeded: " + Mathf.Floor(10 * Mathf.Pow(1.25f, (SaveState.save.maxHealth + SaveState.save.damage - 7)));
            }
        }
        public void lvlDamage()
        {
            Debug.Log(Mathf.Floor(10 * Mathf.Pow(1.25f, (SaveState.save.maxHealth + SaveState.save.damage - 7))));
            if (SaveState.save.lvlpoints > Mathf.Floor(10 * Mathf.Pow(1.25f, (SaveState.save.maxHealth + SaveState.save.damage - 7))))
            {
                SaveState.save.lvlpoints -= (int)(Mathf.Floor(10 * Mathf.Pow(1.25f, (SaveState.save.maxHealth + SaveState.save.damage - 7))));
                SaveState.save.damage++;
                dmg.text = "" + SaveState.save.damage;
                points.text = "Point: " + SaveState.save.lvlpoints + "\nNeeded: " + Mathf.Floor(10 * Mathf.Pow(1.25f, (SaveState.save.maxHealth + SaveState.save.damage - 7)));
            }
        }
        public void play()
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}