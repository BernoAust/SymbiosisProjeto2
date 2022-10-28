using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerConsume))]
public class PlayerBase : MonoBehaviour
{

    public static int Health = 100;

    private void Awake()
    {
        PlayerEvents.playerDamageTaken.AddListener(TakeDamage);
        PlayerEvents.playerDeath.AddListener(OnPlayerDeath);
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
