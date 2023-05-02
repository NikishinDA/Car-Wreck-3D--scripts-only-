using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Dreamteck;
using Dreamteck.Splines;
using SimpleInputNamespace;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float border;
    [SerializeField] private float speed = 10;
    [SerializeField] private PlayerInputManager inputManager;
    [SerializeField] private SplineFollower splineFollower;
    [SerializeField] private float aheadCalculation = 0.01f;
    private SplineComputer _splineComputer;
    [SerializeField] private float rot;
    [SerializeField] private float rotCD;
    private SplineSample _splineSample;
    private float totalRot;
    private readonly WaitForEndOfFrame _waitObj = new WaitForEndOfFrame();
    private Vector3 _aheadPos;
    private Transform _parentTransform;
    private bool _isActive = true;

    private void Awake()
    {
        splineFollower.onNode += SplineFollowerOnNode;
        EventManager.AddListener<DebugCallEvent>(OnDebugCall);
        EventManager.AddListener<GameOverEvent>(OnGameOver);
        EventManager.AddListener<FinisherStartEvent>(OnFinisherStart);

        EventManager.AddListener<FinisherEndEvent>(OnFinisherEnd);
        _parentTransform = transform.parent;
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<DebugCallEvent>(OnDebugCall);
        EventManager.RemoveListener<GameOverEvent>(OnGameOver);
        EventManager.RemoveListener<FinisherStartEvent>(OnFinisherStart);
        EventManager.RemoveListener<FinisherEndEvent>(OnFinisherEnd);
    }

    private void OnFinisherEnd(FinisherEndEvent obj)
    {
        _isActive = false;
    }

    private void OnFinisherStart(FinisherStartEvent obj)
    {
        
        //_isActive = false;
    }

    private void OnGameOver(GameOverEvent obj)
    {
        _isActive = false;
    }

    private void OnDebugCall(DebugCallEvent obj)
    {
        speed = obj.Strafe;
    }

    private void Start()
    {
        _splineComputer = splineFollower.spline;
    }

    public void SetSpline(SplineComputer newSpline)
    {
        _splineComputer = newSpline;
    }
    private IEnumerator Wait()
    {
        yield return _waitObj;
        _splineComputer = splineFollower.spline;
    }
    private void SplineFollowerOnNode(List<SplineTracer.NodeConnection> passed)
    {
        //StartCoroutine(Wait());
       // splineComputer = splineFollower.spline;

    }

    // Update is called once per frame
    void Update()
    {
        if (_isActive)
        {
            float newX = Mathf.Clamp(transform.localPosition.x
                                     + inputManager.TouchDelta * speed,
                -border, border);
            transform.localPosition = newX * Vector3.right;
            transform.localEulerAngles += MoveRotation() + AheadRotation();
        }

    }

    private void LateUpdate()
    {
        //transform.localEulerAngles += MoveRotation() + AheadRotation();
    }

    private Vector3 AheadRotation()
    {
        _aheadPos = _splineComputer.EvaluatePosition(
            DMath.Clamp01(_splineComputer.Travel(splineFollower.result.percent, aheadCalculation)));
        return Vector3.up *
                                      Quaternion.FromToRotation(transform.forward,
                                           _aheadPos - _parentTransform.position).eulerAngles.y;
    }

    private Vector3 MoveRotation()
    {
        
        totalRot += inputManager.TouchDelta * rot - totalRot * Time.deltaTime * rotCD;
        totalRot = Mathf.Clamp(totalRot, -60, 60);
        return Vector3.up * (totalRot );
    }
}