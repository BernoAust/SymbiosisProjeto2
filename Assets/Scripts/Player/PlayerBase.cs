using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerConsume))]
public class PlayerBase : MonoBehaviour
{
    const int MAX_HEALT = 100;


    public static int Health = MAX_HEALT;

    private void Awake()
    {
        this.ResetPlayer();
        PlayerEvents.playerDamageTaken.AddListener(TakeDamage);
        PlayerEvents.playerDeath.AddListener(OnPlayerDeath);
    }

    void ResetPlayer() {
        this.gameObject.SetActive(true);
        Health = MAX_HEALT;
        PlayerEvents.updatePlayerHealth.Invoke(Health);
    }

    void TakeDamage(int damage)
    {
        Health -= damage;
        PlayerEvents.updatePlayerHealth.Invoke(Health);
    }

    private void Update()
    {
        CheckDeath();
    }

    void CheckDeath()
    {
        if(Health <= 0) { PlayerDied(); }
    }

    void PlayerDied()
    {
        PlayerEvents.playerDeath.Invoke();
    }

    void OnPlayerDeath()
    {
        gameObject.SetActive(false);
    }



}
