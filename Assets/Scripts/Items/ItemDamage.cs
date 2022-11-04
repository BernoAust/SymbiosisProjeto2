using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ItemDamage : MonoBehaviour
{

    int Damage = 100;

    private void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerEvents.playerDamageTaken.Invoke(Damage);

        gameObject.SetActive(false);

    }   

}
