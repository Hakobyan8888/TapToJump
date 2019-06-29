using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu3 : MonoBehaviour{

    public string mainMenuLevel;

    public void RestartGame()
    {
        FindObjectOfType<GameManager3>().Reset();

    }
    public void QuitToMain()
    {
        Application.LoadLevel(mainMenuLevel);
    }
}