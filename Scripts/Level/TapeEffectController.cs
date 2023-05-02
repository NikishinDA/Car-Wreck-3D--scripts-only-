using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeEffectController : ObstacleEffectController
{
    [SerializeField] private GameObject tape;
    [SerializeField] private Rigidbody[] poles;
    public override void Activate()
    {
        tape.SetActive(false);
        foreach (var pole in poles)
        {
            pole.useGravity = true;
            pole.isKinematic = false;
            pole.AddExplosionForce(50f, transform.position - transform.forward + Vector3.back,
                15f, 0f, ForceMode.Impulse);
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

        foreach (var pole in poles)
        {
            Destroy(pole.gameObject);
        }
    }
}
