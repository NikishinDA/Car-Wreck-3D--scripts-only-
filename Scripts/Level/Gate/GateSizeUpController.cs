using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSizeUpController : GateController
{
    protected override void OnTriggerEnter(Collider other)
    {
        OnActivate();
        var evt = GameEventsHandler.GateSizeEvent;
        evt.IsGood = true;
        BroadcastGlobalActivateEvent(evt);
    }
}
