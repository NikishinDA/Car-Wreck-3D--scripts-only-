using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSizeDownController : GateController
{
    protected override void OnTriggerEnter(Collider other)
    {
        OnActivate();
        var evt = GameEventsHandler.GateSizeEvent;
        evt.IsGood = false;
        BroadcastGlobalActivateEvent(evt);
    }
}
