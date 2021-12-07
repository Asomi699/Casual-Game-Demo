using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private CharacterAnimation _animation;
    private CharacterMover _mover;
    
    public event UnityAction Fail;
    public event UnityAction Won;

    private void Start()
    {
        _animation = GetComponent<CharacterAnimation>();
        _mover = GetComponent<CharacterMover>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out IObstacle obstacle))
        {
            DisableCollider();
            StopCharacter();
            Fail?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out FinishArea finish))
        {
            Won?.Invoke();
            _animation.Dance();
        }
    }

    private void DisableCollider()
    {
        GetComponent<BoxCollider>().enabled = false;
    }

    private void StopCharacter()
    {
        _mover.Running = false;
    }
}
