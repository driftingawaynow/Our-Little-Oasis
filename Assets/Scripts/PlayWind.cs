using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWind : MonoBehaviour
{
    public AudioSource wind;
    private bool louder = true;
    private bool quieter = false;
    // Start is called before the first frame update
    void Start()
    {
        wind.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(wind.volume);
        if(louder && (wind.volume < 0.1f))
        {
            wind.volume += 0.04f * Time.deltaTime;
        }
        if(quieter && (wind.volume > 0.01f))
        {
            wind.volume -= 0.04f * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        if(other.tag == "Player")
        {
            Debug.Log("bruh?");
            louder = false;
            quieter = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            louder = true;
            quieter = false;
        }
    }
}
