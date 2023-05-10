using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _coinCollectSound;

    public void PlayCoinCollectSound()
    {
        _audioSource.PlayOneShot(_coinCollectSound);
    }
}
