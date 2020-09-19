using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float gravity = 1.0f;
    private CharacterController _controller;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * playerSpeed;
        
        if (_controller.isGrounded)
        {

        }
        else
        {
            velocity.y -= gravity;
        }

        _controller.Move(velocity * Time.deltaTime);
    }
}
