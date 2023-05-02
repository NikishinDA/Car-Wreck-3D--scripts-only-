using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConesEffectController : ObstacleEffectController
{
    [SerializeField] private Rigidbody[] cones;

    public override void Activate()
    {
        foreach (var cone in cones)
        {
            cone.useGravity = true;
            cone.isKinematic = false;
            cone.AddExplosionForce(50f, transform.position - transform.forward + Vector3.down, 15f, 0, ForceMode.Impulse);
            cone.AddTorque(Random.insideUnitSphere * 100f, ForceMode.Impulse);
        }

        StartCoroutine(LifeTimer(5f));
        Taptic.Heavy();

    }

    private IEnumerator LifeTimer(float time)
    {
        for (float t = 0; t < time; t += Time.deltaTime)
        {
            yield return null;
        }

        foreach (var cone in cones )
        {
            Destroy(cone.gameObject);
        }
    }
}

