using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private GameObject _startPanel, _scoreObject, _endPanel, _player;

    [SerializeField]
    private TMP_Text _scoreText, _endScoreText, _highScoreText;

    private int _score;
    private int _Score
    {
        get
        {
            return _score;
        }
        set
        {
            StartCoroutine(UpdateText(value, _scoreText));
            _score = value;
        }
    }

    private int _endScore;
    private int _EndScore
    {
        get
        {
            return _endScore;
        }
        set
        {
            StartCoroutine(UpdateText(value, _endScoreText));
            _endScore = value;
        }
    }

    private int _highScore;
    private int _HighScore
    {
        get
        {
            return _highScore;
        }
        set
        {
            StartCoroutine(UpdateText(value, _highScoreText));
            _highScore = value;
        }
    }

    IEnumerator UpdateText(int finalValue, TMP_Text currentText)
    {
        int currentValue = int.Parse(currentText.text);
        float t = 0;

        while (currentValue < finalValue)
        {
            t += Time.deltaTime;
            currentValue = Mathf.RoundToInt(Mathf.Lerp(currentValue, finalValue, t * 100));
            currentText.text = currentValue.ToString();
            yield return null;
        }
        currentText.text = finalValue.ToString();
    }


    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize the player object here or ensure it's correctly positioned in the scene.
    }



    private void Start()
    {
        _startPanel.SetActive(true);
        _player.SetActive(false);
        _scoreObject.SetActive(false);
        _endPanel.SetActive(false);    
        _Score = 0;
        _endScore = 0;
        _highScore = 0;
    }

    public void UpdateScore(int currentScore)
    {
        _Score = currentScore;
    }

    public void GameStart()
    {
        _startPanel.SetActive(false);
        _scoreObject.SetActive(true);
        _player.SetActive(true);      
    }

    public void GameEnd()
    {
        _scoreObject.SetActive(false);
        _endPanel.SetActive(true);
        _EndScore = _Score;

        // Ensure that the player object is active and initialized here.
        Destroy(_player, 2f); // Adjust the time delay as needed.

        int highScore = PlayerPrefs.HasKey("HighScore") ? PlayerPrefs.GetInt("HighScore") : 0;
        if (_Score > highScore)
        {
            highScore = _Score;
            PlayerPrefs.SetInt("HighScore", highScore); // Store the high score
        }
        _HighScore = highScore;
    }


    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void GameRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
