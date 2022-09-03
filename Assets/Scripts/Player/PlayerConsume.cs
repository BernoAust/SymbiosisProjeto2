using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerConsume : MonoBehaviour
{

    public int Points;

    private void Awake()
    {
        PlayerEvents.playerConsumeObject.AddListener(AddPoints);
    }

    private void Start()
    {
        Points = 0;
    }

    void AddPoints(int points)
    {
        Points += points;
    }

}
