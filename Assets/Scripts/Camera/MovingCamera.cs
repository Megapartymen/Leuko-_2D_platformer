using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    [SerializeField] private Transform _wathObject;
    [SerializeField] private float _positionZ;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_wathObject.position.y >= gameObject.transform.position.y)
        {
            gameObject.transform.position = new Vector3(0, _wathObject.position.y, _positionZ);
        }        
    }
}
