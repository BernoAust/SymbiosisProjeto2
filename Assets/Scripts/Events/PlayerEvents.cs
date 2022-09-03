using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents
{

    // MOVEMENT

    public static UnityEvent playerMovementUp = new UnityEvent();
    public static UnityEvent playerMovementLeft = new UnityEvent();
    public static UnityEvent playerMovementRight = new UnityEvent();
    public static UnityEvent playerMovementDown = new UnityEvent();
    public static UnityEvent playerMovementStopUp = new UnityEvent();
    public static UnityEvent playerMovementStopRight = new UnityEvent();
    public static UnityEvent playerMovementStopLeft = new UnityEvent();
    public static UnityEvent playerMovementStopDown = new UnityEvent();

    // GAMEPLAY

    public static UnityEvent<int> playerConsumeObject = new UnityEvent<int>();
    public static UnityEvent<int> playerDamageTaken = new UnityEvent<int>();
    public static UnityEvent playerDeath = new UnityEvent();

}
