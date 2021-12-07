using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;
    private CharacterMover _characterMover;
    
    private const string START = "Start";
    private const string RUN = "Run";
    private const string IDLE = "Idle";
    private const string DANCE = "Dance";
    private string _currentAnimation;
    
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _characterMover = GetComponent<CharacterMover>();
        SetAnimation(START);
    }

    private void Update()
    {
        if (_characterMover.Running)
            Run();
        else
            Idle();
    }

    public void Dance()
    {
        SetAnimation(DANCE);
    }
    
    private void Run()
    {
        SetAnimation(RUN);
    }

    private void Idle()
    {
        SetAnimation(IDLE);
    }
    
    private void SetAnimation(string animation)
    {
        if (animation != _currentAnimation && _currentAnimation != DANCE)
        {
            DisableCurrentAnimation();
            _animator.SetBool(animation, true);
            _currentAnimation = animation;
        }
    }

    private void DisableCurrentAnimation()
    {
        _animator.SetBool(_currentAnimation, false);
    }
}
