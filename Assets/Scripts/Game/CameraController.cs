using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        var playerPosition = Player.transform.position;

        transform.position = Vector3.Lerp
        (
            transform.position,
            new Vector3(playerPosition.x, playerPosition.y, transform.position.z),
            Time.deltaTime * 10
        ); 
    }
}
