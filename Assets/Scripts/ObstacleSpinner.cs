using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpinner : MonoBehaviour, IObstacle
{
    [SerializeField] private HingeJoint _hingeJoint;
    
    [SerializeField] private float _speed;

    [SerializeField] private bool _counterclockwise;

    private void Start()
    {
        SetDirection();
        SetSpeed();
    }

    private void SetDirection()
    {
        if (_counterclockwise)
            _speed = -_speed;
    }

    private void SetSpeed()
    {
        JointMotor jointMotor = _hingeJoint.motor;
        jointMotor.targetVelocity = _speed;
        
        _hingeJoint.motor = jointMotor;
    }
}
