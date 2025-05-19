using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private GameObject deadScreen;
    private int score;

    private void Start()
    {
        deadScreen.SetActive(false);
        score = 0;
        scoreText.text = score.ToString();
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore");
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }

    private void Update()
    {
        if (!BirdMovement.isBirdAlive)
        {
            deadScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        if (score > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score);
        }

        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
        deadScreen.SetActive(false);
        BirdMovement.isBirdAlive = true;
    }
}
