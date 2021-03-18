using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpAnimation : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private CharacterController _chController;
    [SerializeField] private MovingPlayer _movingPlayer;
    [SerializeField] private AudioSource _jumpSound;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayJumpAnimationOnPC();
        PlayJumpAnimationOnSmartphone();
    }

    private void PlayJumpAnimationOnSmartphone()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            VisualisePrepareJump();
        }

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            VisualiseJump();
        }

        if (_movingPlayer.Gravitation < -2)
        {
            VisualiseLanding();
        }

        TranslateGroundedStatusInAnimator();
    }
    
    private void PlayJumpAnimationOnPC()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            VisualisePrepareJump();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            VisualiseJump();
        }

        if (_movingPlayer.Gravitation < -2)
        {
            VisualiseLanding();
        }

        TranslateGroundedStatusInAnimator();
    }

    private void VisualisePrepareJump()
    {
        _animator.SetBool("PrepareJump", true);
    }

    private void VisualiseJump()
    {
        _animator.SetBool("PrepareJump", false);
        _animator.SetBool("InJump", true);
        _jumpSound.Play();
    }

    private void VisualiseLanding()
    {
        _animator.SetBool("InJump", false);
    }

    private void TranslateGroundedStatusInAnimator()
    {
        if (_chController.isGrounded)
        {
            _animator.SetBool("Grounded", true);
        }
        else
        {
            _animator.SetBool("Grounded", false);
        }
    }
}
