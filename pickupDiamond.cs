using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupDiamond : MonoBehaviour {

    public int diamondToGive;

    private DiamondManager theDiamondManager;

    private AudioSource DiamondSound;

	// Use this for initialization
	void Start () {
        theDiamondManager = FindObjectOfType<DiamondManager>();

        DiamondSound = GameObject.Find("Pickup Coin").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            theDiamondManager.AddDiamond(diamondToGive);
            gameObject.SetActive(false);

            if (DiamondSound.isPlaying)
            {
                DiamondSound.Stop();
                DiamondSound.Play();
            }
            else
            {
                DiamondSound.Play();
            }
        }
    }

}
