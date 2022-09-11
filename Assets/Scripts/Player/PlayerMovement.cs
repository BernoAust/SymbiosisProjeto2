using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    float movementSpeed = 5f;

    private void FixedUpdate()
    {
        float horiontalMovement = Input.GetAxisRaw("Horizontal") * Time.deltaTime * movementSpeed;
        float verticalMovement = Input.GetAxisRaw("Vertical") * Time.deltaTime * movementSpeed;

        transform.position += new Vector3(horiontalMovement, verticalMovement, 0);
    }
}
