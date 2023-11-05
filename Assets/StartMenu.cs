using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{
    public Button startButton;

    private bool gameStarted = false;

    private void Start()
    {
        // Add an event listener to the button
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        if (!gameStarted)
        {
            // Load your game scene here. Replace "GameScene" with your actual game scene name.
            SceneManager.LoadScene("GameScene");

            // Set the gameStarted flag to true to prevent multiple scene loads.
            gameStarted = true;

            // Hide the button after the game starts
            startButton.gameObject.SetActive(false);
        }
    }
}
