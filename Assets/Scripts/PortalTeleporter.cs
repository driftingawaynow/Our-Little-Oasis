using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform receiver;
    private bool playerIsOverlapping = false;
    private float dotProduct = 0f;
    private float tempX = 0f;
    private float tempY = 0f;
    private float tempZ = 0f;
    private Vector3 portalToPlayer;
    private float timer = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerIsOverlapping)
        {
            playerIsOverlapping = false;
            portalToPlayer = player.position - transform.position;
            dotProduct = Vector3.Dot(transform.forward, portalToPlayer);
            Debug.Log(dotProduct);
            //Debug.Log(player.position);
            tempX = player.position.x;
            tempY = player.position.y;
            tempZ = player.position.z;
            if(dotProduct > 0f)
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
                //Debug.Log(player.position);

                playerIsOverlapping = false;
            }
        }

        if(timer > 0f)
        {
            timer -= 0.5f * Time.deltaTime;
        }
    }

    void OnTriggerEnter (Collider other) 
    {
        if(other.tag == "Player" && timer <= 0f) {
            playerIsOverlapping = true;
            //Debug.Log("Overlap");
        }
    }

    void OnTriggerExit (Collider other) 
    {
        if(other.tag == "Player") {
            playerIsOverlapping = false;
        }
    }
}
