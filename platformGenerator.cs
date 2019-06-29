using System;
using UnityEngine;

public class platformGenerator : MonoBehaviour
{

    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;
    private float[] platformWidths;

    public GameObject[] thePlatforms;
    private int platformSelector;

    private float minHeight;
    public Transform maxHeihtPoint;
    private float maxHeight;

    public float maxHeightChange;
    private float heightChange;

    // Use this for initialization
    void Start()
    {
        // platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;

        platformWidths = new float[thePlatforms.Length];

        for(int i =0; i<thePlatforms.Length; i++)
        {
            platformWidths[i] = thePlatforms[i].GetComponent<BoxCollider2D>().size.x;

        }

        minHeight = transform.position.y;
        maxHeight = maxHeihtPoint.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = UnityEngine.Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = UnityEngine.Random.Range(0, thePlatforms.Length);

            heightChange = transform.position.y + UnityEngine.Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }


            transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] + distanceBetween,heightChange, transform.position.z);

            Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);
        }
    }
}
