using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteActive : MonoBehaviour
{
    public Transform player;
    public Animator anim;
    public AudioSource source;
    public Collider col;
    public ParticleSystem particles;
    public AudioSource emitter;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("WestActive") == 1)
        {
            if(col.tag == "West")
            {
                extendAnimation(false);
            }
        }

        if(PlayerPrefs.GetInt("NorthActive") == 1)
        {
            if(col.tag == "North")
            {
                extendAnimation(false);
            }
        }

        if(PlayerPrefs.GetInt("EastActive") == 1)
        {
            if(col.tag == "East")
            {
                extendAnimation(false);
            }
        }
    }

    IEnumerator enableParticles()
    {
        yield return new WaitForSeconds(13);
        particles.Play();
        emitter.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            switch(col.tag)
            {
                case "West":
                    if(PlayerPrefs.GetInt("WestActive") != 1)
                    {
                        extendAnimation(true);
                    }
                    PlayerPrefs.SetInt("WestActive", 1);
                    break;
                case "North":
                    if(PlayerPrefs.GetInt("NorthActive") != 1)
                    {
                        extendAnimation(true);
                    }
                    PlayerPrefs.SetInt("NorthActive", 1);
                    break;
                case "East":
                    if(PlayerPrefs.GetInt("EastActive") != 1)
                    {
                        extendAnimation(true);
                    }
                    PlayerPrefs.SetInt("EastActive", 1);
                    break;
            }
        }
    }

    public void extendAnimation(bool audio)
    {
        anim.Play("Extend");
        if(audio)
        {
            source.Play();
        }
        StartCoroutine(enableParticles());
    }
}
