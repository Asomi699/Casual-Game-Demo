using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Confetti : MonoBehaviour
{
    [SerializeField] private ParticleSystem _confettiTemplate;
    [SerializeField] private AudioClip _confettiSound;

    private AudioSource _audioSource;
    private ParticleSystem _confetti;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
        CreateEffect();
    }

    public void Shoot()
    {
        PlayAnimation();
        PlaySound();
    }

    private void CreateEffect()
    {
        _confetti = Instantiate(_confettiTemplate, this.transform);
    }

    private void PlayAnimation()
    {
        _confetti.Play();
    }

    private void PlaySound()
    {
        _audioSource.PlayOneShot(_confettiSound);
    }
}
