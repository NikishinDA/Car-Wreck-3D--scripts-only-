using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesEffectController : ObstacleEffectController
{

    public override void Activate()
    {
        Taptic.Heavy();
    }
}
