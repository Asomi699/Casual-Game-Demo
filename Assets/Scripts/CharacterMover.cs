using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMover : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;
    
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceTravelled;
    
    private Rigidbody _rigidbody;
    private float _lookPointOffset = 1;
    private float _positionY;

    public bool Running { get; set; }
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.MovePosition(_pathCreator.path.GetPointAtDistance(_distanceTravelled));
        _positionY = _rigidbody.transform.position.y;
    }

    private void Update()
    {
        if (Running)
            Move();
    }

    public void Move()
    {
        CalculateNextPoint();
        
        MoveToNextPoint();
        
        TurnTowards();
    }

    private void CalculateNextPoint()
    {
        _distanceTravelled += _speed * Time.deltaTime;
    }
    
    private void MoveToNextPoint()
    {
        Vector3 nextPoint = _pathCreator.path.GetPointAtDistance(_distanceTravelled, EndOfPathInstruction.Stop);
        nextPoint.y = _positionY; 
        _rigidbody.MovePosition(nextPoint);
    }

    private void TurnTowards()
    {
        Vector3 lookPoint = _pathCreator.path.GetPointAtDistance(_distanceTravelled + _lookPointOffset);
        lookPoint.y = transform.position.y;
        transform.LookAt(lookPoint);
    }
}
