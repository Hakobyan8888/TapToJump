using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagaer1 : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController1 thePlayer1;
    public PlayerController2 thePlayer2;

    private Vector3 playerStartPoint;

    private platformDeleter[] platformList;

    private ScoreManager theScoreManager;

    public DeathMenu theDeathScreen;
    


    // Use this for initialization
    void Start()
    {

        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer1.transform.position;
        playerStartPoint = thePlayer2.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();

       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResartGame()
    {

        theScoreManager.scoreIncreasing = false;
        thePlayer1.gameObject.SetActive(false);
        thePlayer2.gameObject.SetActive(false);

        theDeathScreen.gameObject.SetActive(true);

        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        theDeathScreen.gameObject.SetActive(false);
        platformList = FindObjectsOfType<platformDeleter>();
        for (int i = 0; i < platformList.Length; i++)
        {
            Destroy(platformList[i].gameObject);
        }

        thePlayer1.transform.position = playerStartPoint;
        thePlayer2.transform.position = playerStartPoint;

        platformGenerator.position = platformStartPoint;

        thePlayer1.gameObject.SetActive(true);
        thePlayer2.gameObject.SetActive(true);

        theScoreManager.pointsPerSecond = theScoreManager.pointsPerSecondStore;
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }

    /*public IEnumerator RestartGameCo()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<platformDeleter>();

        for (int i = 0; i < platformList.Length; i++)
        {
            Destroy(platformList[i].gameObject);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.pointsPerSecond = theScoreManager.pointsPerSecondStore;
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }*/
    }









