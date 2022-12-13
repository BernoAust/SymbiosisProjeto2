using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionController : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform BulletSpawner;
    public int Damage;
    public int Points;

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

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            PlayerEvents.playerDamageTaken.Invoke(Damage);
            PlayerEvents.playerConsumeObject.Invoke(Points);
            AudioEvent.playAudio.Invoke("Destroy_AnimalHostil");
            AudioEvent.playAudio.Invoke("Attack_Slime1");
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate() {
        if (this.PlayerGO != null) {
            this.transform.right = this.PlayerGO.transform.position - this.transform.position;
            this.transform.rotation = new Quaternion(
                0,
                this.transform.rotation.y,
                this.transform.rotation.z,
                this.transform.rotation.w
            );
        }
    }

    void Attack() {
        if (this.BulletPrefab != null) {
            Instantiate(
                this.BulletPrefab,
                this.BulletSpawner.position,
                Quaternion.identity
            );
            AudioEvent.playAudio.Invoke("Attack_Escorpiao");
        }
    }
}
