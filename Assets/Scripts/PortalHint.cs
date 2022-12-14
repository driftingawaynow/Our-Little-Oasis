using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalHint : MonoBehaviour
{
    public Material glow;
    private float intensity = 0f;
    private bool fadeInBool = false;
    private bool fadeOutBool = false;
    public AudioSource audioS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeInBool)
        {
            StartCoroutine(glowFadeIn());
        }
        if(fadeOutBool)
        {
            StartCoroutine(glowFadeOut());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if portal is not enabled, play hint
        if(other.tag == "Player" && (PlayerPrefs.GetInt("WestActive") == 0 || PlayerPrefs.GetInt("NorthActive") == 0 || PlayerPrefs.GetInt("EastActive") == 0))
        {
            glow.EnableKeyword ("_EMISSION");
            fadeInBool = true;
            audioS.Play();
        }
    }

    /// <summary>
    /// Smoothly fades in emissive material on each stone
    /// </summary>
    IEnumerator glowFadeIn()
    {
        intensity += 1f * Time.deltaTime;
        glow.SetColor("_EmissionColor", new Color(1.0f,1.0f,1.0f,1.0f) * intensity);
        if(intensity >= 1)
        {
            fadeInBool = false;
            fadeOutBool = true;
            yield return null;
        }
    }

    IEnumerator glowFadeOut()
    {
        intensity -= 1f * Time.deltaTime;
        glow.SetColor("_EmissionColor", new Color(1.0f,1.0f,1.0f,1.0f) * intensity);
        if(intensity <= 0)
        {
            fadeOutBool = false;
            yield return null;
        }
    }
}
