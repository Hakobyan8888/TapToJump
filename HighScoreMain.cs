using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class HighScoreMain : MonoBehaviour
{
    private ScoreManager ScoreCount;
    public float Score;
    public Text highScoreText;

    public void Start()
    {
        ScoreCount = FindObjectOfType<ScoreManager>();
        if (PlayerPrefs.HasKey("HighScore"))
        {
            Score = PlayerPrefs.GetFloat("HighScore");
        }
    }
    public void Update()
    {
        highScoreText.text = "High Score: " + Mathf.Round(Score);
        PlayerPrefs.SetFloat("HighScore", Score);
    }
    public void AddDiamond(int pointsToAdd)
    {
        Score += pointsToAdd;
        PlayerPrefs.SetFloat("HighScore", Score);
    }
}
