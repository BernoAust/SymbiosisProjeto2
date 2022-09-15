using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents
{
    // GAMEPLAY
    public static UnityEvent<int> playerConsumeObject = new UnityEvent<int>();
    public static UnityEvent<int> playerDamageTaken = new UnityEvent<int>();
    public static UnityEvent playerDeath = new UnityEvent();

}
