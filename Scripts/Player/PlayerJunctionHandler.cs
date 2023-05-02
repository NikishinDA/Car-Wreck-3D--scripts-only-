using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class PlayerJunctionHandler : MonoBehaviour
{
    private SplineFollower _follower;
    [SerializeField] private Transform modelTransform;
    [SerializeField] private PlayerMover playerMover;
    [SerializeField] private double switchPositionOffset = 0.001d;
    private void Awake()
    {
        _follower = GetComponent<SplineFollower>();
    }
    private void OnEnable()
    {
        _follower.onNode += OnNode;
    }
    private void OnDisable()
    {
        _follower.onNode -= OnNode;
    }
    private void OnNode (List<SplineTracer.NodeConnection> passed)
    {
        Debug.Log("Reached node " + passed[0].node.name + " connected at point " +
                  passed[0].point);
        NodeController nc = passed[0].node.GetComponent<NodeController>();
        if (nc)
            if (!nc.IsValid(modelTransform.localPosition.x)) return;
        Node.Connection[] connections = passed[0].node.GetConnections();
        if (connections.Length == 1) return;
        int currentConnection = 0;
        for (int i = 0; i < connections.Length; i++)
        {
            if (connections[i].spline == _follower.spline && connections[i].pointIndex ==
                passed[0].point)
            {
                currentConnection = i;
                break;
            }
        }
        if (currentConnection > 0) return;
        int newConnection = 1;//Random.Range(0, connections.Length);
        /*if(newConnection == currentConnection)
        {
            newConnection++;
            if (newConnection >= connections.Length) newConnection = 0;
        }*/
        SwitchSpline(connections[currentConnection], connections[newConnection]);
        EventManager.Broadcast(GameEventsHandler.LevelSplineChangeEvent);
    }
    void SwitchSpline(Node.Connection from, Node.Connection to)
    {
        //float excessDistance =
        //    _follower.spline.CalculateLength(_follower.spline.GetPointPercent(from.pointIndex),
        //        _follower.UnclipPercent(_follower.result.percent));
        _follower.spline = to.spline;
        _follower.RebuildImmediate();
        double startPercent = _follower.ClipPercent(to.spline.GetPointPercent(to.pointIndex)) + switchPositionOffset;
        _follower.direction = Spline.Direction.Forward;
        _follower.SetPercent(startPercent);
        playerMover.SetSpline(to.spline);
    }
}
