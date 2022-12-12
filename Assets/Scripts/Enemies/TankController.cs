using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform BulletSpawner;
    public int Damage;
    public int Points;

    GameObject PlayerGO;
    Animator TankAnimator;
    IEnumerator Coroutine;

    private void Awake() {
        this.TankAnimator = this.gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            this.PlayerGO = other.gameObject;
            this.TankAnimator.SetBool("isAttacking", true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            this.PlayerGO = null;
            this.TankAnimator.SetBool("isAttacking", false);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            PlayerEvents.playerDamageTaken.Invoke(Damage);
            PlayerEvents.updatePlayerPoints.Invoke(Points);
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate() {
        if (this.PlayerGO != null) {
            this.transform.right = this.PlayerGO.transform.position - this.transform.position;
        }
    }

    void Attack() {
        if (this.BulletPrefab != null && this.BulletSpawner != null) {
            Instantiate(
                this.BulletPrefab,
                this.BulletSpawner.position,
                Quaternion.identity
            );
        }
    }
}
