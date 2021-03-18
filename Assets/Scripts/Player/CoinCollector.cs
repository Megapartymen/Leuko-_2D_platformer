using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private AudioSource _collectSound;
    [SerializeField] private TextMesh _score;

    private int _coinCounter;

    private void Start()
    {
        _coinCounter = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            _collectSound.Play();
            _coinCounter += 1;
            _score.text = _coinCounter.ToString();
        }
    }
}
