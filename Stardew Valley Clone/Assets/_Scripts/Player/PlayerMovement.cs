using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    
    private float horizontal;
    private float vertical;
    private float moveLimiter = 0.7f;

    [SerializeField] private float runSpeed = 20.0f;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _playerVisual;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        if (horizontal != 0 || vertical != 0)
        {
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }

        if (horizontal > 0)
        {
            _playerVisual.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontal < 0)
        {
            _playerVisual.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        } 

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
