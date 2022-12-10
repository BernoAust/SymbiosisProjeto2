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

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            SoldierAnimator.SetBool("isAttackMode", false);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            PlayerEvents.playerDamageTaken.Invoke(Damage);
            PlayerEvents.updatePlayerPoints.Invoke(Points);
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
        }
    }
}
