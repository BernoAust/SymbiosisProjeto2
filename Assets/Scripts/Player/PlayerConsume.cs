using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerConsume : MonoBehaviour
{

    public int Points;

    private void Awake()
    {
        PlayerEvents.playerConsumeObject.AddListener(AddPoints);
    }

    private void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<BoxCollider2D>().isTrigger = true;
        Points = 0;
    }

    void AddPoints(int points)
    {
        Points += points;
        PlayerEvents.updatePlayerPoints.Invoke(Points);
    }

}
