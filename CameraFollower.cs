using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(Platformer2DUserControl))]
    public class CameraFollower : MonoBehaviour
    {
        Transform player;
        float offsetX;

        // Use this for initialization
        void Start()
        {
           GameObject player_go = GameObject.FindGameObjectWithTag("Player");

            if (player_go == null)
            {
                Debug.LogError("Couldnt find GameObject Named Player");
                return;
            }
            player = player_go.transform;

            offsetX =transform.position.x - player.position.x;

        }

        // Update is called once per frame
        void Update()
        {
            if (player != null) {
                Vector3 pos = transform.position;
                pos.x = player.position.x + offsetX;
                transform.position = pos;
            }
            
        }
    }
}
