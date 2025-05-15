using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private int score;

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
