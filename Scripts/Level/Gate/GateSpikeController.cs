using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSpikeController : GateController
{
    protected override void OnTriggerEnter(Collider other)
    {
        OnActivate();
        BroadcastGlobalActivateEvent(GameEventsHandler.GateSpikeEvent);
    }
}
