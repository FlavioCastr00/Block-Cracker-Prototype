using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;

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
}
