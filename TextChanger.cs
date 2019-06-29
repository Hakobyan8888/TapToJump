using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour {

    public Text Play;
    public MainMenu SecondPlayer;

	// Use this for initialization
	void Start () {
        SecondPlayer = FindObjectOfType<MainMenu>();
	}

    // Update is called once per frame
    void Update()
    {
        if (SecondPlayer.SecondPlayerBought == 1)
        {
            Play.text = "Play";
        }
    }
}
