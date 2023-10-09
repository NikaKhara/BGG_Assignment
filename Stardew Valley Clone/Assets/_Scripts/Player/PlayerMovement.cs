using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _body;
    
    private float _horizontal;
    private float _vertical;
    private float _moveLimiter = 0.7f;

    [SerializeField] private float runSpeed = 20.0f;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _playerVisual;

    void Start ()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        if (_horizontal != 0 || _vertical != 0)
        {
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }

        if (_horizontal > 0)
        {
            _playerVisual.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_horizontal < 0)
        {
            _playerVisual.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void FixedUpdate()
    {
        if (_horizontal != 0 && _vertical != 0)
        {
            _horizontal *= _moveLimiter;
            _vertical *= _moveLimiter;
        } 

        _body.velocity = new Vector2(_horizontal * runSpeed, _vertical * runSpeed);
    }
}
