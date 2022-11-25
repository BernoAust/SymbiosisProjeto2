using System.Collections;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    const string PLAYER_TAG = "Player";
    const float ATTACK_INTERVAL = 4f;
    const float SPEED = 15;
    const int DAMAGE = 30;

    IEnumerator AttackCoroutine = null;
    Vector3 NextPosition;
    Transform PlayerTransform;

    void Awake() {
        this.NextPosition = this.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == PLAYER_TAG) {
            this.PlayerTransform = other.gameObject.transform;
            this.AttackCoroutine = this.Attack(other.transform);
            StartCoroutine(AttackCoroutine);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == PLAYER_TAG) {
            this.PlayerTransform = null;
            StopCoroutine(this.AttackCoroutine);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.tag == PLAYER_TAG) {
            PlayerEvents.playerDamageTaken.Invoke(DAMAGE);
            Destroy(this.gameObject);
        }
    }

    private void Update() {
        this.Move();
    }

    IEnumerator Attack(Transform playerTransform) {
        while (true) {
            if (this.PlayerTransform != null) {
                this.transform.right = this.PlayerTransform.position - this.transform.position;
            }

            this.NextPosition = playerTransform.position;

            yield return new WaitForSeconds(ATTACK_INTERVAL);
        }
    }

    void Move() {
        if (this.NextPosition != null && this.transform.position != this.NextPosition) {
            this.transform.position = Vector2.MoveTowards(
                this.transform.position,
                this.NextPosition,
                SPEED * Time.deltaTime
            );
        }
    }
}
