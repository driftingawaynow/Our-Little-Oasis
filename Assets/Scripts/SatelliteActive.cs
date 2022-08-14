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

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator enableParticles()
    {
        yield return new WaitForSeconds(13);
        particles.Play();
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
                        extendAnimation();
                    }
                    PlayerPrefs.SetInt("WestActive", 1);
                    break;
                case "North":
                    if(PlayerPrefs.GetInt("NorthActive") != 1)
                    {
                        extendAnimation();
                    }
                    PlayerPrefs.SetInt("NorthActive", 1);
                    break;
                case "East":
                    if(PlayerPrefs.GetInt("EastActive") != 1)
                    {
                        extendAnimation();
                    }
                    PlayerPrefs.SetInt("EastActive", 1);
                    break;
            }
        }
    }

    public void extendAnimation()
    {
        anim.Play("Extend");
        source.Play();
        StartCoroutine(enableParticles());
    }
}
