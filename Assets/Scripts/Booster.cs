using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] private AudioSource _BoostAudioSource;
    [SerializeField] private GameObject _BoostBody;
    // Start is called before the first frame update
    private void Awake()
    {
        _BoostAudioSource.volume = 0.3f;
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            _BoostAudioSource.Play();
            Destroy(_BoostBody);
        }
    }

}
