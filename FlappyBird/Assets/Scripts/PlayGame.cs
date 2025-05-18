using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
