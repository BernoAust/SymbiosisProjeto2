using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    // ANIMATION

    Animator animator;

    //GENERAL MOVEMENT

    float movementSpeed = 5f;
    float horizontalAxis;
    float verticalAxis;

    //MOBILE MOVEMENT

    Joystick joystick;
    public bool isMobile = true;




    private void Awake() {
        animator = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    private void FixedUpdate()
    {

        if (!isMobile)
        {
            horizontalAxis = Input.GetAxisRaw("Horizontal");
            verticalAxis = Input.GetAxisRaw("Vertical");
        }
        else
        {
            horizontalAxis = joystick.Horizontal;
            verticalAxis = joystick.Vertical;
        }

        float horiontalMovement = horizontalAxis * Time.deltaTime * movementSpeed;
        float verticalMovement = verticalAxis * Time.deltaTime * movementSpeed;

        animator.SetFloat("Horizontal", horizontalAxis);
        animator.SetFloat("Vertical", verticalAxis);

        transform.position += new Vector3(horiontalMovement, verticalMovement, 0);

        animator.SetFloat("Speed", transform.position.magnitude);
    }
}
