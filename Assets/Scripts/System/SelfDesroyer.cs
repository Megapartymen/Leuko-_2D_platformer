using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDesroyer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private float _hightDestroy;

    private void Start()
    {
        _hightDestroy = 20;
        _player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        DestroyYourself();
    }

    private void DestroyYourself()
    {
        if (gameObject.transform.position.y <= _player.position.y - _hightDestroy)
        {
            Destroy(gameObject);
        }
    }
}
