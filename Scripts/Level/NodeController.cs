using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    [SerializeField] private float width;
    [SerializeField] private bool isRight;

    public bool IsValid(float x)
    {
        return isRight && x > 0 || !isRight && x < 0;
    }
}
