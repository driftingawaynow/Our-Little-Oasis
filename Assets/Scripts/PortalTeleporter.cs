using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform receiver;
    private bool playerIsOverlapping = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
            //Debug.Log(dotProduct);
            Debug.Log(player.position);
            float tempX = player.position.x;
            float tempY = player.position.y;
            float tempZ = player.position.z;
            if(dotProduct < 1f)
            {
                // Teleport
                float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 posOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                Vector3 p = player.position;
                p = receiver.position + posOffset;
                p.x = tempX;
                p.y = tempY;
                p.z = tempZ + 2273f;
                player.position = p;
                Debug.Log(player.position);

                playerIsOverlapping = false;
            }
        }
    }

    void OnTriggerEnter (Collider other) 
    {
        if(other.tag == "Player") {
            playerIsOverlapping = true;
            Debug.Log("Overlap");
        }
    }

    void OnTriggerExit (Collider other) 
    {
        if(other.tag == "Player") {
            playerIsOverlapping = false;
        }
    }
}
