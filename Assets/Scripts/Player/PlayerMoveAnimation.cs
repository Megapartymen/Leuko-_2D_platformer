using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveAnimation : MonoBehaviour
{
    [SerializeField] private float _angleStepRotation;

    private void Update()
    {
        AnimatingMoveOnPC();
        AnimatingMoveOnSmartphone();
    }

    private void AnimatingMoveOnSmartphone()
    {
            transform.rotation *= Quaternion.AngleAxis(Input.acceleration.x * -_angleStepRotation, new Vector3(0, 0, 1));
    }
    
    private void AnimatingMoveOnPC()
    {
        if (Input.GetKey(KeyCode.LeftArrow))            
            RotateObject(1);

        if (Input.GetKey(KeyCode.RightArrow))
            RotateObject(-1);
    }

    private void RotateObject(int direction)
    {
        transform.rotation *= Quaternion.AngleAxis(_angleStepRotation * direction, new Vector3(0, 0, 1));
    }
}
