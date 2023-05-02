using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerModelSizeManager : MonoBehaviour
{
    [SerializeField] private PlayerPropertiesManager propertiesManager;
    private Vector3 _startSize;
    private Sequence _sizeBumpSequence;
    private float _oldSize = 1f;
    private void Awake()
    {
        _startSize = transform.localScale;
        propertiesManager.SizeChange += ChangeSize;
        EventManager.AddListener<DebugCallEvent>(OnDebugCall);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<DebugCallEvent>(OnDebugCall);

    }

    private void OnDebugCall(DebugCallEvent obj)
    {
        transform.localScale = Vector3.one * obj.Size;
        _startSize = Vector3.one * obj.Size;
        _oldSize = obj.Size;
    }

    private void ChangeSize(float size)
    {
        _sizeBumpSequence = DOTween.Sequence();
        _sizeBumpSequence.Append(
            transform.DOScale(_startSize * (size + Mathf.Sign(size - _oldSize) * 0.1f), 0.1f));
        _sizeBumpSequence.Append(transform.DOScale(_startSize * size, 0.1f));
        _sizeBumpSequence.Play();
        _oldSize = size;
    }
}
