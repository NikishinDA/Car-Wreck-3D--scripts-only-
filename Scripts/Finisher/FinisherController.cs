using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinisherController : MonoBehaviour
{
    [SerializeField] private GameObject actionCamera;

    private void Awake()
    {
        EventManager.AddListener<FinisherPlayEvent>(OnFinisherPlay);
        EventManager.AddListener<FinisherEndEvent>(OnFinisherEnd);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<FinisherPlayEvent>(OnFinisherPlay);
        EventManager.RemoveListener<FinisherEndEvent>(OnFinisherEnd);

    }

    private void OnFinisherEnd(FinisherEndEvent obj)
    {
        VarSaver.StarsNum = obj.HitType switch
        {
            HitType.Light => 1,
            HitType.Medium => 2,
            HitType.Full => 3,
            _ => throw new ArgumentOutOfRangeException()
        };
        StartCoroutine(WinScreenWait(5f));
    }

    private void OnFinisherPlay(FinisherPlayEvent obj)
    {
        //actionCamera.SetActive(true);
        //StartCoroutine(CameraWait(1.5f));
    }

    public void FinisherCameraActivate()
    {
        actionCamera.SetActive(true);

    }
    public void TriggerMiss()
    {
        var evt = GameEventsHandler.GameOverEvent;
        evt.IsWin = false;
        EventManager.Broadcast(evt);
    }

    private IEnumerator WinScreenWait(float time)
    {
        yield return new WaitForSeconds(time);
        var evt = GameEventsHandler.GameOverEvent;
        evt.IsWin = true;
        EventManager.Broadcast(evt);
    }

    private IEnumerator CameraWait(float time)
    {
        yield return  new WaitForSeconds(time);
        actionCamera.SetActive(true);
    }
}
