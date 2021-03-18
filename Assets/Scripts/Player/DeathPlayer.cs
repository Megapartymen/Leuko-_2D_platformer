using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _deadMusic;
    [SerializeField] private GameObject _jumpAnimation;
    [SerializeField] private GameObject _moveAnimation;
    [SerializeField] private GameObject _light;

    private SphereCollider _sphereCollider;
    private CharacterController _characterController;
    private ParticleSystem _explosion; 

    private void Start()
    {
        _sphereCollider = gameObject.GetComponent<SphereCollider>();
        _characterController = gameObject.GetComponent<CharacterController>();
        _explosion = gameObject.GetComponent<ParticleSystem>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            Death();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Enemy enemy))
        {
            Death();        
        }
    }

    private void Death()
    {
        _deadMusic.Play();
        _explosion.Play();
        Destroy(_jumpAnimation);
        Destroy(_moveAnimation);
        Destroy(_light);
        Destroy(GetComponent<MovingPlayer>());
        _sphereCollider.enabled = false;
        _characterController.enabled = false;
    }
}
