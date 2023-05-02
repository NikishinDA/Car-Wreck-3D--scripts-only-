using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private SplineComputer startSpline;
    [SerializeField] private SplineComputer[] allSplines;
    public void SetPlayer(SplineFollower follower)
    {
        follower.spline = startSpline;
    }

    private void Awake()
    {
        float length = 0;
        float[] splinesLength = new float[allSplines.Length];
        for (var i = 0; i < allSplines.Length; i++)
        {
            float slength = allSplines[i].CalculateLength();
            length += slength;
            splinesLength[i] = slength;
        }

        var evt = GameEventsHandler.LevelLoadEvent;
        evt.Length = splinesLength;
        EventManager.Broadcast(evt);
    }

    public void OnUserCross()
    {
        /*var evt = GameEventsHandler.GameOverEvent;
        evt.IsWin = true;
        EventManager.Broadcast(evt);*/
        EventManager.Broadcast(GameEventsHandler.FinisherStartEvent);
    }
    public void OnUserReachPit()
    {
        var evt = GameEventsHandler.GameOverEvent;
            evt.IsWin = false;
            EventManager.Broadcast(evt);
    }
}
