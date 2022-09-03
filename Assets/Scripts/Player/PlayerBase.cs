using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerConsume))]
public class PlayerBase : MonoBehaviour
{

    public int Health;

    private void Awake()
    {
        PlayerEvents.playerDamageTaken.AddListener(TakeDamage);
        PlayerEvents.playerDeath.AddListener(OnPlayerDeath);
    }

    private void Start()
    {
        Health = 100;
    }

    void TakeDamage(int damage)
    {
        Health -= damage;
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
