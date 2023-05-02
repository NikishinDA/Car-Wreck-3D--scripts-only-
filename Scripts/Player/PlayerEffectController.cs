using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerEffectController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private PlayerPropertiesManager playerProperties;
    [SerializeField] private ParticleSystem[] fireTrails;
    private void Awake()
    {
        EventManager.AddListener<GameOverEvent>(OnGameOver);
        EventManager.AddListener<FinisherEndEvent>(OnFinisherEnd);
        EventManager.AddListener<FinisherStartEvent>(OnFinisherStart);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<GameOverEvent>(OnGameOver);
        EventManager.RemoveListener<FinisherEndEvent>(OnFinisherEnd);
        EventManager.RemoveListener<FinisherStartEvent>(OnFinisherStart);

    }

    private void OnFinisherStart(FinisherStartEvent obj)
    {
        foreach (var fireTrail in fireTrails)
        {
            fireTrail.Play();
        }
    }

    private void OnFinisherEnd(FinisherEndEvent obj)
    {
        playerRB.transform.SetParent(null);
        playerRB.useGravity = true;
        playerRB.isKinematic = false;
        playerRB.AddForce(transform.forward * playerProperties.PlayerProperties.Speed * 25f, ForceMode.Impulse);        playerRB.AddTorque(Random.insideUnitSphere * 100f, ForceMode.Impulse);
        playerRB.AddTorque(Random.insideUnitSphere * 100f, ForceMode.Impulse);

        StartCoroutine(LifeTime(10f));

    }

    private void OnGameOver(GameOverEvent obj)
    {
        if (obj.IsWin) return;
        LaunchCar();
    }

    private void LaunchCar()
    {
        playerRB.transform.SetParent(null);
        playerRB.useGravity = true;
        playerRB.isKinematic = false;
        Vector3 direction = Random.insideUnitCircle;
        direction.z = direction.y;
        direction.y = 1;
        playerRB.AddForce(direction * 10f, ForceMode.Impulse);
        playerRB.AddTorque(Random.insideUnitSphere * 100f, ForceMode.Impulse);
        StartCoroutine(LifeTime(10f));
    }

    private IEnumerator LifeTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(playerRB.gameObject);
    }
}
