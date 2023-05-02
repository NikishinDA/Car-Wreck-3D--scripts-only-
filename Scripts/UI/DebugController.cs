using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugController : MonoBehaviour
{
    [SerializeField] private InputField speedInput;
    [SerializeField] private InputField strafeInput;
    [SerializeField] private InputField sizeInput;
    [SerializeField] private InputField nosInput;
    [SerializeField] private Button startButton;
    private float _speed;
    private float _strafe;
    private float _size;
    private int _nos;

    private void Awake()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
        _speed = PlayerPrefs.GetFloat("DebugSpeed", 35);
        _strafe = PlayerPrefs.GetFloat("DebugStrafe", 20);
        _size = PlayerPrefs.GetFloat("DebugSize", 2);
        _nos = PlayerPrefs.GetInt("DebugNOS", 10);
        speedInput.text = _speed.ToString();
        strafeInput.text = _strafe.ToString();
        sizeInput.text = _size.ToString();
        nosInput.text = _nos.ToString();
    }

    private void OnStartButtonClick()
    {
        var evt = GameEventsHandler.DebugCallEvent;
        Single.TryParse(speedInput.text, out _speed);
        Single.TryParse(strafeInput.text, out _strafe);
        Single.TryParse(sizeInput.text, out _size);
        Int32.TryParse(nosInput.text, out _nos);
        evt.Speed = _speed;
        evt.Strafe = _strafe;
        evt.Size = _size;
        evt.NOS = _nos;
        PlayerPrefs.SetFloat("DebugSpeed", _speed);
        PlayerPrefs.SetFloat("DebugStrafe", _strafe);
        PlayerPrefs.SetFloat("DebugSize", _size);
        PlayerPrefs.SetInt("DebugNOS", _nos);
        PlayerPrefs.Save();
        EventManager.Broadcast(evt);
    }
}
