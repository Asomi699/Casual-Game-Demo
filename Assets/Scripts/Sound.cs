using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip _cry;
    [SerializeField] private AudioClip _kick;

    private Player _player;
    private AudioSource _audioSource;
    
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.Fail += OnPlaySoundDrop;
    }

    private void OnPlaySoundDrop()
    {
        _audioSource.PlayOneShot(_kick);
        _audioSource.PlayOneShot(_cry);
        
        _player.Fail -= OnPlaySoundDrop;
    }
}
