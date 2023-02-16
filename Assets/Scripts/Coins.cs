using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    [SerializeField] private AudioSource _GoldAudioSource;
    [SerializeField] private GameObject _Coin;

    private void Awake()
    {
        _GoldAudioSource.volume = 1f;
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Profit.InstanceProfit.AddProfit();
            _GoldAudioSource.Play();
            Destroy(_Coin);
        }
    }

}
