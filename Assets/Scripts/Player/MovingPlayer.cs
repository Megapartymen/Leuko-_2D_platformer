using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer : MonoBehaviour
{
    private CharacterController _chController;    
    [SerializeField] private float _speedMove;
    [SerializeField] private float _maxJumpPower;
    [SerializeField] private float _minJumpPover;
    private float _currentJumpPower;
    
    public float Gravitation { get; private set; }

    private Vector3 _moveDirection;

    private void Start()
    {
        _chController = GetComponent<CharacterController>();
        _currentJumpPower = _minJumpPover;
    }

    private void Update()
    {
        SetGravity();
        MoveKeyboard();
        MoveSmartphone();
    }

    private void MoveSmartphone()
    {
        ZeroingMoveDirection();

        if (Input.acceleration.x <1 && Input.acceleration.x >-1)
        {
            _moveDirection.x = Input.acceleration.x * _speedMove * 5;
        }

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Stationary  && _chController.isGrounded && _currentJumpPower <= _maxJumpPower)
            CalculateJumpPover();

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended && _chController.isGrounded)
        {
            ImplementJump();
        }

        ApplyMoveOnCharacterController();
    }
    
    private void MoveKeyboard()
    {
        ZeroingMoveDirection();
        
        if (Input.GetKey(KeyCode.RightArrow))
            _moveDirection.x = 1 * _speedMove;

        if (Input.GetKey(KeyCode.LeftArrow))
            _moveDirection.x = -1 * _speedMove;

        if (Input.GetKey(KeyCode.Space) && _chController.isGrounded && _currentJumpPower <= _maxJumpPower)
            CalculateJumpPover();

        if (Input.GetKeyUp(KeyCode.Space) && _chController.isGrounded)
        {
            ImplementJump();
        }

        ApplyMoveOnCharacterController();
    }

    private void SetGravity()
    {
        if (!_chController.isGrounded)
            Gravitation -= 40f * Time.deltaTime;
        else
            Gravitation = -1f;
    }

    private void ZeroingMoveDirection()
    {
        _moveDirection = Vector3.zero;
    }

    private void ApplyMoveOnCharacterController()
    {
        _moveDirection.y = Gravitation;
        _chController.Move(_moveDirection * Time.deltaTime);
    }

    private void ImplementJump()
    {
        Gravitation = _currentJumpPower;
        _currentJumpPower = _minJumpPover;
    }

    private void CalculateJumpPover()
    {
        _currentJumpPower += Mathf.Lerp(_minJumpPover, _maxJumpPower, 0.02f) - _minJumpPover;
    }
}
