using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteActive : MonoBehaviour
{
    public Transform player;
    public Animator anim;
    public AudioSource source;
    public Collider col;
    private bool once = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if(!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetInt("Score", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(PlayerPrefs.GetInt("Score"));
    }

    IEnumerator incrementScore()
    {
        yield return new WaitForSeconds(15);
        int temp = PlayerPrefs.GetInt("Score") + 1;
        PlayerPrefs.SetInt("Score", temp);
        once = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(once)
            {
                col.enabled = false;
                anim.Play("Extend");
                source.Play();
                StartCoroutine(incrementScore());
            }
        }
    }
}
