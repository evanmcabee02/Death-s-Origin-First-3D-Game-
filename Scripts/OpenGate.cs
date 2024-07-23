using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OriginGame
{

    public class OpenGate : MonoBehaviour
    {
        public GameObject uiNotice;
        public GameObject uiNotice2;
        public GameObject door1;
        public GameObject door2;
        public KeyCode interactKey = KeyCode.E;
        public Vector3 closeRot1;
        public Vector3 closeRot2;
        public Vector3 openRot1;
        public Vector3 openRot2;
        bool open = false;
        public bool locked = false;
        public string keyItem = "";
        float time = 1.5f;
        void OnTriggerEnter()
        {
            uiNotice.SetActive(true);
        }
        void OnTriggerExit()
        {
            uiNotice.SetActive(false);
            uiNotice2.SetActive(false);
        }
        void OnTriggerStay(Collider other)
        {
            if (Input.GetKey(interactKey) && other.gameObject.tag == "Player")
            {
                StartCoroutine(ToggleDoor());
            }
        }
        IEnumerator ToggleDoor()
        {
            if (locked)
            {
                foreach (Item item in Inventory.playerInventory.Items)
                {
                    if (item.iName == keyItem)
                    {
                        locked = false;
                    }
                }
                if (locked)
                {
                    uiNotice2.SetActive(true);
                }
            }
            else
            {
                if (open)
                {
                    for (float t = 0; t < 1; t += Time.deltaTime / time)
                    {
                        door1.transform.localRotation = Quaternion.Euler(Vector3.Lerp(openRot1, closeRot1, t));
                        door2.transform.localRotation = Quaternion.Euler(Vector3.Lerp(openRot2, closeRot2, t));
                        yield return null;
                    }
                    open = false;
                }
                else
                {
                    for (float t = 0; t < 1; t += Time.deltaTime / time)
                    {
                        door1.transform.localRotation = Quaternion.Euler(Vector3.Lerp(closeRot1, openRot1, t));
                        door2.transform.localRotation = Quaternion.Euler(Vector3.Lerp(closeRot2, openRot2, t));
                        yield return null;
                    }
                    open = true;
                }
            }
        }
    }
}