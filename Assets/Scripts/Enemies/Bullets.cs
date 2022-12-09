using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    const int SPEED = 15;
    const int LIFETIME_SECONDS = 3;

    public int Damage;

    Vector3 PlayerPosition;
    IEnumerator Coroutine;

    

    void Awake() {
        this.PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    void Start() {
        this.transform.right = this.PlayerPosition - this.transform.position;

        this.Coroutine = this.DestroySelf();
        StartCoroutine(this.Coroutine);
    }

    IEnumerator DestroySelf() {
        while(true) {
            yield return new WaitForSeconds(LIFETIME_SECONDS);
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            PlayerEvents.playerDamageTaken.Invoke(Damage);
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate() {
        this.transform.Translate(Vector2.right * SPEED * Time.deltaTime);
    }
}
