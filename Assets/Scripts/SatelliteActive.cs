using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteActive : MonoBehaviour
{
    public Transform player;
    public Animator anim;
    public AudioSource source;
    bool once = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void incrementScore()
    {
        EnablePortal.score += 1;
        once = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(once)
            {
                anim.Play("Extend");
                source.Play();
                incrementScore();
            }
        }
    }
}
