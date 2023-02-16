using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierTrigger : Score
{
    [SerializeField] private AudioSource _FrictionAudioSource;

    private void Awake()
    {
        _FrictionAudioSource.volume = 0.9f;
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            _FrictionAudioSource.Play();
        }
    }

    
}
