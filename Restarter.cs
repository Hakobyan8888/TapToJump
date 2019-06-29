using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {

        private ScoreManager theScoreManager;

        void Start()
        {
            theScoreManager = FindObjectOfType<ScoreManager>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            theScoreManager.scoreIncreasing = false;
            if (other.tag == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
            }
            theScoreManager.scoreCount = 0;
            theScoreManager.scoreIncreasing = true;
        }
    }
}
