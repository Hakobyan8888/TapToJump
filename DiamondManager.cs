using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class DiamondManager : MonoBehaviour {

    public Text diamondText;

    public float diamondCount;

    public float pointsPerDiamond;

    public bool diamondIncreasing;


	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("Diamonds"))
        {
            diamondCount = PlayerPrefs.GetFloat("Diamonds");
        }
    }
	
	// Update is called once per frame
	void Update () {
        diamondText.text = "Diamonds: " + Mathf.Round( diamondCount);
        PlayerPrefs.SetFloat("Diamonds", diamondCount);
    }

    public void AddDiamond(int pointsToAddDiamonds)
    {
        diamondCount += pointsToAddDiamonds;
        PlayerPrefs.SetFloat("Diamonds", diamondCount);
    }

}
