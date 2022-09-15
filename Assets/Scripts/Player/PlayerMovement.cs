using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    float movementSpeed = 5f;

    Animator animator;

    private void Awake() {
        animator = gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");

        float horiontalMovement = horizontalAxis * Time.deltaTime * movementSpeed;
        float verticalMovement = verticalAxis * Time.deltaTime * movementSpeed;

        animator.SetFloat("Horizontal", horizontalAxis);
        animator.SetFloat("Vertical", verticalAxis);

        transform.position += new Vector3(horiontalMovement, verticalMovement, 0);

        animator.SetFloat("Speed", transform.position.magnitude);
    }
}
