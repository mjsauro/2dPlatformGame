using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float gravity = 1.3f;
    [SerializeField] private float jumpHeight = 25.0f;
    private CharacterController _controller;

    //cached variables
    private float _yVelocity;
    private bool _canDoubleJump = false;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * playerSpeed;
        
        HandleJump();

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);

        //reset double jump when back to zero
        if (_controller.isGrounded)
        {
            _canDoubleJump = false;
        }
    }

    private void HandleJump()
    {
        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = jumpHeight;
                _canDoubleJump = true;
            }
        }
        else if (_canDoubleJump && Input.GetKeyDown(KeyCode.Space))
        {
            _yVelocity = jumpHeight;
            _canDoubleJump = false;
        }
        else
        {
            _yVelocity -= gravity;
        }
    }
}
