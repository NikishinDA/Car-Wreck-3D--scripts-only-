using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        EventManager.Broadcast(GameEventsHandler.MoneyCollectEvent);
        Taptic.Light();
        gameObject.SetActive(false);
    }
}
