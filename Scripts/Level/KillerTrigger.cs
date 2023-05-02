using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var evt = GameEventsHandler.GameOverEvent;
        evt.IsWin = false;
        EventManager.Broadcast(evt);
        Taptic.Heavy();
    }
}
