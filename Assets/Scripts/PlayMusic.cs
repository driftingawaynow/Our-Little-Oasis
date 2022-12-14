using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource music;
    private bool fadeOut = false;
    private float timeOut = 0f;

    // Update is called once per frame
    void Update()
    {
        if(timeOut > 0f)
        {
            timeOut -= 3f * Time.deltaTime;
        }

        // fade out music if player leaves vicinity of tower
        if(fadeOut)
        {
            if (music.volume <= 0.01f)
            {
                music.Stop();
                fadeOut = false;
            }
            else
            {
                float newVolume = music.volume - (0.1f * Time.deltaTime);  //change 0.01f to something else to adjust the rate of the volume dropping
                if (newVolume < 0f)
                {
                    newVolume = 0f;
                }
                music.volume = newVolume;
            }   
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && timeOut <= 0f)
        {
            fadeOut = false;
            music.volume = .25f;
            music.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            fadeOut = true;
            timeOut = 1f;
        }
    }
}
