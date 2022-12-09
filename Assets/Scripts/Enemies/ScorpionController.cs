using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionController : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform BulletSpawner;

    GameObject PlayerGO;
    Animator ScorpionAnimator;

    private void Awake() {
        this.ScorpionAnimator = this.gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            this.PlayerGO = other.gameObject;
            this.ScorpionAnimator.SetBool("isAttacking", true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            this.PlayerGO = null;
            this.ScorpionAnimator.SetBool("isAttacking", false);
        }
    }

    private void FixedUpdate() {
        if (this.PlayerGO != null) {
            this.transform.right = this.PlayerGO.transform.position - this.transform.position;
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
