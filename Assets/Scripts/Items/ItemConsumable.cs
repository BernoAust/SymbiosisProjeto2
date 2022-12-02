using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ItemConsumable : MonoBehaviour
{

    public int Points = 10;

    private void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        PlayerEvents.playerConsumeObject.Invoke(Points);
        
        PlayAudio(gameObject.tag);
        gameObject.SetActive(false);

    }

    private void PlayAudio(string type)
    {
        AudioEvent.playAudio.Invoke($"Destroy_{type}");
    }

}
