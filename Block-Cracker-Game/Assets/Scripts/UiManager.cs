using UnityEditor.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
    public GameObject gameOverPanel;

    private int currentScore = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentScoreText.text = currentScore.ToString();
    }

    public void UpdateCurrentScore(int amount)
    {
        currentScore += amount;
        currentScoreText.text = currentScore.ToString();
    }

    public void SetGameOverPannelActive()
    {
        gameOverPanel.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
