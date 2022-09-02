using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents
{
    public static UnityEvent playerMovementUp = new UnityEvent();
    public static UnityEvent playerMovementLeft = new UnityEvent();
    public static UnityEvent playerMovementRight = new UnityEvent();
    public static UnityEvent playerMovementDown = new UnityEvent();
    public static UnityEvent playerMovementStopUp = new UnityEvent();
    public static UnityEvent playerMovementStopRight = new UnityEvent();
    public static UnityEvent playerMovementStopLeft = new UnityEvent();
    public static UnityEvent playerMovementStopDown = new UnityEvent();
}
