using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreDisplay;
    private int _currentCoins = 0;

    private void Start()
    {
        scoreDisplay.text = $"Coins {_currentCoins}";
    }

    private void Update()
    {

    }

    public void UpdateCoinDisplay(int coins)
    {
        _currentCoins += coins;
        scoreDisplay.text = $"Coins {_currentCoins}";
    }
}
