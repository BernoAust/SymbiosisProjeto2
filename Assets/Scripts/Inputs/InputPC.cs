using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPC : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            PlayerEvents.playerMovementUp.Invoke();
        }
        
        if(Input.GetKeyDown(KeyCode.S))
        {
            PlayerEvents.playerMovementDown.Invoke();
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            PlayerEvents.playerMovementLeft.Invoke();
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            PlayerEvents.playerMovementRight.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            PlayerEvents.playerMovementStopUp.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            PlayerEvents.playerMovementStopDown.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            PlayerEvents.playerMovementStopLeft.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            PlayerEvents.playerMovementStopRight.Invoke();
        }

    }
}
