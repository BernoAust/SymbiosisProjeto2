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


    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            this.PlayerGO = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            this.PlayerGO = null;
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
