using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    private void Start()
    {
        PlayerEvents.playerDeath.AddListener(ShowMessage);
    }

    void ShowMessage()
    {
        Debug.Log("Player est� morto.");
    }
}
