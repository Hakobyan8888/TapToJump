using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager3 : MonoBehaviour
{

    public Transform platformGenerator;
    private Vector3 platformStartPoint;



    public PlayerController3 thePlayer3;

    private Vector3 playerStartPoint;

    private platformDeleter[] platformList;

    private ScoreManager theScoreManager;

    public DeathMenu3 theDeathScreen;



    // Use this for initialization
    void Start()
    {

        platformStartPoint = platformGenerator.position;
        playerStartPoint =thePlayer3.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResartGame()
    {

        theScoreManager.scoreIncreasing = false;
        thePlayer3.gameObject.SetActive(false);

        theDeathScreen.gameObject.SetActive(true);

        Time.timeScale = 0f;


        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {

        Time.timeScale = 1f;

        thePlayer3.transform.position = playerStartPoint;

        platformGenerator.position = platformStartPoint;

        theDeathScreen.gameObject.SetActive(false);
        platformList = FindObjectsOfType<platformDeleter>();
        for (int i = 0; i < platformList.Length; i++)
        {
            Destroy(platformList[i].gameObject);
        }

        thePlayer3.gameObject.SetActive(true);

        theScoreManager.pointsPerSecond = theScoreManager.pointsPerSecondStore;
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }

}
