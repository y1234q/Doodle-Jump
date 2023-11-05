using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Button startButton;

    private int score = 0;
    private bool gameStarted = false;

    private void Start()
    {
        // Attach a method to the Start button's click event.
        startButton.onClick.AddListener(StartGame);
    }

    private void Update()
    {
        if (gameStarted)
        {
            // Check if the player landed on a platform (you should implement your own logic for this).
            if (PlayerLandedOnPlatform())
            {
                // Increase the score when the player lands on a platform.
                score++;
                UpdateScoreText();
            }
        }
    }

    private void StartGame()
    {
        // Disable the Start button once the game starts.
        startButton.interactable = false;
        gameStarted = true;
    }

    private bool PlayerLandedOnPlatform()
    {
        // Implement your logic to detect if the player landed on a platform.
        // You may use raycasting, collision detection, or other methods.
        // Return true if the player landed on a platform, otherwise, return false.
        return false;
    }

    private void UpdateScoreText()
    {
        // Update the TextMeshPro text component to display the current score.
        scoreText.text = "Score: " + score;
    }
}
