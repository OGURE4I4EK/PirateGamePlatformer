using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    public GameObject winPanel;
    public GameObject lossPanel;
    private int score = 0;
    public int winScore = 2;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Монеты" + score;

        if (score >= winScore)
        {
            WinGame();
        }

    }

    private void WinGame()
    {
        winPanel.SetActive(true);
        Time.timeScale = 1f;
    }
    public void LossGame()
    {
        lossPanel.SetActive(true);
        Time.timeScale = 1f;
    }
}
