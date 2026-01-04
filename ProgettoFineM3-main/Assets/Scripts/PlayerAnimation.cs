using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _playerController;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        //gestione animazioni se il player si muove

        if (_playerController.Direction != Vector2.zero)
        {
            _animator.SetBool("isMoving", true);
            _animator.SetFloat("xSpeed", _playerController.Direction.x);
            _animator.SetFloat("ySpeed", _playerController.Direction.y);
        }
        else
        {
            _animator.SetBool("isMoving", false);
        }
    }
}