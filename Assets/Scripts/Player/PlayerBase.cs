using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerConsume))]
public class PlayerBase : MonoBehaviour
{
    const int MAX_HEALT = 100;
    const int PHASE_1_POINTS = 500;
    const int PHASE_2_POINTS = 1025;


    public static int Health = MAX_HEALT;
    
    int PlayerPoints = 1750;
    bool hasGrownFirstPhase = false;
    bool hasGrownSecondPhase = false;
    Vector3 BaseScale;
    float NextScaleX;
    float NextScaleY;

    private void Awake()
    {
        this.ResetPlayer();

        this.BaseScale = this.transform.localScale;
        this.NextScaleX = this.BaseScale.x;
        this.NextScaleY = this.BaseScale.y;

        PlayerEvents.playerDamageTaken.AddListener(TakeDamage);
        PlayerEvents.playerDeath.AddListener(OnPlayerDeath);
        PlayerEvents.updatePlayerPoints.AddListener(ConsumePoints);
    }

    void ResetPlayer() {
        this.gameObject.SetActive(true);
        Health = MAX_HEALT;
        PlayerEvents.updatePlayerHealth.Invoke(Health);
    }

    void TakeDamage(int damage)
    {
        // Health -= damage;
        // PlayerEvents.updatePlayerHealth.Invoke(Health);
    }

    void CheckDeath()
    {
        if(Health <= 0) { PlayerDied(); }
    }

    void CheckPointsAndGrow() {        
        var shouldEnterPhaseOne = this.PlayerPoints >= PHASE_1_POINTS && !this.hasGrownFirstPhase;
        var shouldEnterPhaseTwo = this.PlayerPoints >= PHASE_2_POINTS && !this.hasGrownSecondPhase;

        if (shouldEnterPhaseOne || shouldEnterPhaseTwo) {
                float scaleX = this.BaseScale.x;
                float scaleY = this.BaseScale.y;

                float newScaleX = scaleX;
                float newScaleY = scaleY;

            if (shouldEnterPhaseOne) {
                newScaleX = scaleX * 1.5f;
                newScaleY = scaleY * 1.5f;

                this.hasGrownFirstPhase = true;
            } else if (shouldEnterPhaseTwo) {
                newScaleX = scaleX * 2.0f;
                newScaleY = scaleY * 2.0f;

                this.hasGrownSecondPhase = true;
            }


            this.NextScaleX = newScaleX;
            this.NextScaleY = newScaleY;

            this.BaseScale = new Vector3(newScaleX, newScaleY, 1);
        }
    }

    void PlayerDied()
    {
        PlayerEvents.playerDeath.Invoke();
    }

    void OnPlayerDeath()
    {
        gameObject.SetActive(false);
    }

    void ConsumePoints(int points) {
        this.PlayerPoints = points;
    }

    void Update() {
        CheckDeath();
        CheckPointsAndGrow();

        bool shouldScaleX = this.transform.localScale.x <= this.NextScaleX;
        bool shouldScaleY = this.transform.localScale.y <= this.NextScaleY;

        if (shouldScaleX && shouldScaleY) {
            float smoothVelocity = 0.85f;

            this.transform.localScale = new Vector3(
                Mathf.SmoothDamp(this.transform.localScale.x, this.NextScaleX, ref smoothVelocity, 0.3f),
                Mathf.SmoothDamp(this.transform.localScale.y, this.NextScaleY, ref smoothVelocity, 0.3f),
                1
            );
        }
    }
}
