using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Player _player;
    
     private CinemachineBrain _cinemachine;

    private void Start()
    {
        _cinemachine = GetComponent<CinemachineBrain>();
    }

    private void OnEnable()
    {
        _player.Fail += OnDisableCinemachine;
        _player.Won += OnDisableCinemachine;
    }

    private void OnDisable()
    {
        _player.Fail -= OnDisableCinemachine;
        _player.Won -= OnDisableCinemachine;
    }
    
    private void OnDisableCinemachine()
    {
        _cinemachine.enabled = false;
    }
}
