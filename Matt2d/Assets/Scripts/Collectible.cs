using UnityEngine;

public class Collectible : MonoBehaviour
{

    //TODO: may remove ui manager here?

    private Player _player;
    //private UIManager _uiManager;

    private void Start()
    {
        //init cached references;
        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.Log("Player is null");
        }

        //_uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        //if (_uiManager == null)
        //{
        //    Debug.Log("UI Manager is null");
        //}
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player.AddCoins(1);
            //_uiManager.UpdateCoinDisplay(1);
            Destroy(gameObject);
        }

    }
}
