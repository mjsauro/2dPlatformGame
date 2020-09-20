using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float gravity = 1.3f;
    [SerializeField] private float jumpHeight = 25.0f;
    [SerializeField] private int playerCoins = 0;
    [SerializeField] private int currentLives = 3;
    
    public Vector3 startingPosition;

    //cached references
    private CharacterController _controller;
    private UIManager _uiManager;
    //cached variables
    private float _yVelocity;
    private bool _canDoubleJump;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();

        var position = transform.position;
        startingPosition = new Vector3(position.x, position.y);

        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.Log("UI Manager is null");
        }

        _uiManager.UpdateLivesDisplay(currentLives);
        _uiManager.UpdateCoinDisplay(playerCoins);
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
        _uiManager.UpdateCoinDisplay(coins);
    }

    private void UpdateLives(int lives)
    {
        currentLives += lives;
        _uiManager.UpdateLivesDisplay(currentLives);
    }

    public void PlayerDamage()
    {
        UpdateLives(-1);

        if (currentLives < 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
