using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioEvent
{

    public static UnityEvent<string> playAudio = new UnityEvent<string>();
    public static UnityEvent<string> stopAudio = new UnityEvent<string>();

}
