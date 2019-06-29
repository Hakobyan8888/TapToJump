using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;

    public float scoreCount;
    public  float highScoreCount;

    public float pointsPerSecond;
    public float pointsPerSecondStore;

    public bool scoreIncreasing;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
        pointsPerSecondStore = pointsPerSecond;
	}
	
	// Update is called once per frame
	void Update () {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }
        if (scoreCount >= 500)
        {
            pointsPerSecond = 8;
        }
        if (scoreCount >= 1000)
        {
            pointsPerSecond = 10;
        }
        if (scoreCount >= 2000)
        {
            pointsPerSecond = 12;
        }
        if (scoreCount >= 2500)
        {
            pointsPerSecond = 14;
        }
        if (scoreCount >= 3000)
        {
            pointsPerSecond = 16;
        }
        if (scoreCount> highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round( scoreCount);
        highScoreText.text = "High Score: " + Mathf.Round (highScoreCount);
	}

    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }

}
