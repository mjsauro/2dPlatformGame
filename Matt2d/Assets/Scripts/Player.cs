using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float gravity = 1.3f;
    [SerializeField] private float jumpHeight = 25.0f;
    [SerializeField] private int playerCoins = 0;
    
    private CharacterController _controller;

    //cached variables
    private float _yVelocity;
    private bool _canDoubleJump;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
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

    public void AddCoins(int coins)
    {
        playerCoins += coins;
    }
}
