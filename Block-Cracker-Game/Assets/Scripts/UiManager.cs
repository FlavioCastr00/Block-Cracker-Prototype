using UnityEditor.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highestScoreText;
    public GameObject gameOverPanel;

    private int currentScore = 0;
    private int highestScore = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.LoadHighestScore();
        highestScore = GameManager.Instance.highestScore;

        currentScoreText.text = currentScore.ToString();
        highestScoreText.text = highestScore.ToString();
    }

    public void UpdateCurrentScore(int amount)
    {
        currentScore += amount;
        currentScoreText.text = currentScore.ToString();
    }

    public void SetGameOverPannelActive()
    {
        if (currentScore > highestScore)
        {
            GameManager.Instance.highestScore = currentScore;
            GameManager.Instance.SaveHighestScore();

        }
        gameOverPanel.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
