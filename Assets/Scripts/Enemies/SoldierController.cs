using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform BulletSpawner;
    public int Damage;
    public int Points;

    GameObject PlayerGO;
    Animator SoldierAnimator;

    void Awake() {
        this.SoldierAnimator = this.gameObject.GetComponent<Animator>();
        this.PlayerGO = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            SoldierAnimator.SetBool("isAttackMode", true);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Vector2 result = gameObject.transform.position - other.gameObject.transform.position;
            if(result.x > 2f)
            {
                SoldierAnimator.SetFloat("Vertical", 0f);
                SoldierAnimator.SetFloat("Horizontal", -1f);
            }
            else if(result.x <= -2f)
            {
                SoldierAnimator.SetFloat("Vertical", 0f);
                SoldierAnimator.SetFloat("Horizontal", 1f);
            }
            else if (-2f < result.x && result.x < 2f && result.y > 0)
            {
                SoldierAnimator.SetFloat("Horizontal", 0f);
                SoldierAnimator.SetFloat("Vertical", -1f);
            }
            else
            {
                SoldierAnimator.SetFloat("Vertical", 0f);
                SoldierAnimator.SetFloat("Horizontal", 1f);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            SoldierAnimator.SetBool("isAttackMode", false);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            PlayerEvents.playerDamageTaken.Invoke(Damage);
            PlayerEvents.playerConsumeObject.Invoke(Points);
            AudioEvent.playAudio.Invoke("Destroy_Soldado");
            AudioEvent.playAudio.Invoke("Attack_Slime2");
            Destroy(this.gameObject);
        }
    }

    void Attack() {
        if (this.BulletPrefab != null) {
            Instantiate(
                this.BulletPrefab,
                this.BulletSpawner.position,
                Quaternion.identity
            );
            AudioEvent.playAudio.Invoke("Attack_Soldado");
        }
    }
}
