using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSpeedDownController : GateController
{
    protected override void OnTriggerEnter(Collider other)
    {
        OnActivate();
        var evt = GameEventsHandler.GateSpeedEvent;
        evt.IsGood = false;
        BroadcastGlobalActivateEvent(evt);
    }
}
