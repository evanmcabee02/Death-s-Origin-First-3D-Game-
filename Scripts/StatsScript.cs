using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace OriginGame
{
    public class StatsScript : MonoBehaviour
    {

        private int PlayerHealth;
        public int kills;
        public static StatsScript player;
        public GameObject weapon;
        public LayerMask m_LayerMask;
        Vector3 beginPos = new Vector3(0.5f, 0, 0.5f);
        Vector3 endPos = new Vector3(0.5f, -.1f, 0.9f);
        Vector3 beginRot = new Vector3(0, 90, 0);
        Vector3 endRot = new Vector3(70, 60, 131);
        float time = 0.5f;
        bool attacking = false;
        public ProgressBar healthBar;

        public float invincibilityDurationSeconds;
        public float delayBetweenInvincibilityFlashes;
        public bool isInvincible;
        public Animator animator;
        [SerializeField] private GameObject model;
        public GameObject AttackAnim;
        // Start is called before the first frame update
        void Start()
        {
            player = this;
            StartCoroutine(SetHealth());
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!attacking)
                {
                    StartCoroutine(Attack(beginPos, endPos, time));
                }
            }
            if(Input.GetMouseButtonDown(1)){
                if(!attacking){
                    StartCoroutine(SuperAttack());
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha1)) weapon.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Alpha2)) weapon.SetActive(true);
        }

        public void TakeDamage(int damage)
        {
            animator.SetTrigger("Hit");
            if (isInvincible == false)
            {
                PlayerHealth -= damage;
                healthBar.BarValue = (PlayerHealth * 100 / SaveState.save.maxHealth);
                if (PlayerHealth <= 0)
                {

                    SaveState.save.lvlpoints += kills;
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                    SceneManager.LoadScene("LevelUp");
                }
                StartCoroutine(IFrames());
            }
        }
        private IEnumerator SuperAttack(){
            AttackAnim.SetActive(true);
            attacking = true;
            yield return new WaitForSeconds(0.1f);
            AttackAnim.SetActive(false);
            yield return new WaitForSeconds(2.9f);
            attacking = false;
            
        }
        private IEnumerator Attack(Vector3 beginPos, Vector3 endPos, float time)
        {
            attacking = true;
            CapsuleCollider wpColl = weapon.GetComponent<CapsuleCollider>();
            wpColl.enabled = true;
            for (float t = 0; t < 1; t += Time.deltaTime / time)
            {
                weapon.transform.localPosition = Vector3.Lerp(beginPos, endPos, t);
                weapon.transform.localRotation = Quaternion.Euler(Vector3.Lerp(beginRot, endRot, t));
                yield return null;
            }
            attacking = false;
            for (float t = 0; t < 1; t += Time.deltaTime / (time / 2))
            {
                weapon.transform.localPosition = Vector3.Lerp(endPos, beginPos, t);
                weapon.transform.localRotation = Quaternion.Euler(Vector3.Lerp(endRot, beginRot, t));
                yield return null;
            }
            wpColl.enabled = false;
        }
        private IEnumerator SetHealth()
        {
            yield return new WaitForSeconds(0.5f);
            PlayerHealth = SaveState.save.maxHealth;
            healthBar.BarValue = ((float)PlayerHealth / (float)SaveState.save.maxHealth) * 100;
        }

        private void ScaleModelTo(Vector3 scale)
        {
            model.transform.localScale = scale;
        }

        private IEnumerator IFrames()
        {
            isInvincible = true;

            for (float i = 0; i < invincibilityDurationSeconds; i += delayBetweenInvincibilityFlashes)
            {
                if (model.transform.localScale == new Vector3(0.16f, 0.16f, 0.16f))
                {
                    ScaleModelTo(Vector3.zero);
                }
                else
                {
                    ScaleModelTo(new Vector3(0.16f, 0.16f, 0.16f));
                }
                yield return new WaitForSeconds(delayBetweenInvincibilityFlashes);
            }
            ScaleModelTo(new Vector3(0.16f, 0.16f, 0.16f));

            isInvincible = false;
        }
    }
}