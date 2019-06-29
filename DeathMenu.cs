using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

    public string mainMenuLevel;

    public void RestartGame()
    {
        FindObjectOfType<GameManagaer1>().Reset();

    }
    public void QuitToMain()
    {
        Application.LoadLevel(mainMenuLevel);
    }
}
