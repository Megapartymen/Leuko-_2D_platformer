using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    [SerializeField] private float _angleStepRotation;

    private int _direction;
    private float _speedMove;

    private void Start()
    {
        _direction = 1;
        _speedMove = Random.Range(1f, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ReorientedTrigger reorientedTrigger))
        {
            _direction *= -1;
        }
    }

    private void Update()
    {
        Move(_direction);
    }
    
    private void Move(int direction)
    {
        transform.Translate(new Vector3(_speedMove * Time.deltaTime * _direction, 0, 0), Space.World);
        transform.rotation *= Quaternion.AngleAxis(_angleStepRotation * _direction, new Vector3(0, 0, -1));
    }
}
