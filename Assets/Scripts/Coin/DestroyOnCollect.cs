using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollect : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = gameObject.GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _particleSystem.Play();
            Destroy(gameObject.transform.Find("DNAAnimation").gameObject);
            Destroy(GetComponent<Coin>());
            Destroy(GetComponent<Collider>());
        }
    }
}
