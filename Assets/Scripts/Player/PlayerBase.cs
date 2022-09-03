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
    }

    private void Start()
    {
        Health = 100;
    }

    void TakeDamage(int damage)
    {
        Health -= damage;
    }

}
