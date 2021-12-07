using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Water : MonoBehaviour
{
    [SerializeField] private AudioClip _soundWater;
    [SerializeField] private ParticleSystem _splashingTemplate;

    private AudioSource _audioSource;
    private ParticleSystem _splashing;
    
    private float _offsetY = 0.05f;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        CreateEffect();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BodyPlayer body))
        {
            Vector3 positionSplashing = body.transform.position;
            positionSplashing.y = transform.position.y + _offsetY;
           
            PlaySplashAnimation(positionSplashing);
            PlaySplashSound();
        }
    }

    private void CreateEffect()
    {
      _splashing = Instantiate(_splashingTemplate, this.transform);
    }

    private void PlaySplashAnimation(Vector3 positionSplashing)
    {
        _splashing.transform.position = positionSplashing;
        _splashing.Play();
    }

    private void PlaySplashSound()
    {
        _audioSource.PlayOneShot(_soundWater);
    }
}
