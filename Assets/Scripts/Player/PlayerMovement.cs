using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 playerVelocity;
    float movementSpeed = 5.5f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        EventHandler();
    }

    private void Start()
    {
        rb.gravityScale = 0;
    }

    private void Update()
    {
        rb.velocity = playerVelocity;
    }

    void EventHandler()
    {
        PlayerEvents.playerMovementUp.AddListener(MoveUp);
        PlayerEvents.playerMovementRight.AddListener(MoveRight);
        PlayerEvents.playerMovementLeft.AddListener(MoveLeft);
        PlayerEvents.playerMovementDown.AddListener(MoveDown);
        PlayerEvents.playerMovementStopUp.AddListener(MoveUpStop);
        PlayerEvents.playerMovementStopRight.AddListener(MoveRightStop);
        PlayerEvents.playerMovementStopLeft.AddListener(MoveLeftStop);
        PlayerEvents.playerMovementStopDown.AddListener(MoveDownStop);
    }

    void MoveRight()
    {
        playerVelocity += Vector2.right * movementSpeed;
    }

    void MoveLeft()
    {
        playerVelocity += Vector2.left * movementSpeed;
    }

    void MoveDown()
    {
        playerVelocity += Vector2.down * movementSpeed;
    }

    void MoveUp()
    {
        playerVelocity += Vector2.up * movementSpeed;
    }

    void MoveRightStop()
    {
        playerVelocity -= Vector2.right * movementSpeed;
    }

    void MoveLeftStop()
    {
        playerVelocity -= Vector2.left * movementSpeed;
    }

    void MoveDownStop()
    {
        playerVelocity -= Vector2.down * movementSpeed;
    }

    void MoveUpStop()
    {
        playerVelocity -= Vector2.up * movementSpeed;
    }

}
