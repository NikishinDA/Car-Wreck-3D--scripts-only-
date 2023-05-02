using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        EventManager.Broadcast(GameEventsHandler.NitroCollectEvent);
        Taptic.Light();
        gameObject.SetActive(false);//tbc
    }
}
