using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePortal : MonoBehaviour
{
    public Transform player;
    public MeshRenderer mesh;
    public MeshCollider mCollider;
    public Terrain terrain;
    public Renderer left;
    public Renderer middle;
    public Renderer right;
    public Material mat;
    public AudioSource audio1;
    public AudioSource audio2;
    public AudioSource audio3;
    private int east = 0;
    private int north = 0;
    private int west = 0;
    private bool playOnce1 = true;
    private bool playOnce2 = true;
    private bool playOnce3 = true;
    private bool playOnce4 = true;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        west = PlayerPrefs.GetInt("WestActive");
        north = PlayerPrefs.GetInt("NorthActive");
        east = PlayerPrefs.GetInt("EastActive");

        if (Input.GetKeyDown("f1") && (Input.GetKeyDown("e")))
        {
            PlayerPrefs.SetInt("WestActive", 1);
            PlayerPrefs.SetInt("NorthActive", 1);
            PlayerPrefs.SetInt("EastActive", 1);
        }

        if(east == 1 && playOnce1)
        {
            playOnce1 = false;
            left.GetComponent<MeshRenderer>().material = mat;
            audio1.Play();
        }

        if(north == 1 && playOnce2)
        {
            playOnce2 = false;
            middle.GetComponent<MeshRenderer>().material = mat;
            audio1.Play();
        }

        if(west == 1 && playOnce3) 
        {
            playOnce3 = false;
            right.GetComponent<MeshRenderer>().material = mat;
            audio1.Play();
        }

        if(west == 1 && north == 1 && east == 1 && playOnce4)
        {
            playOnce4 = false;
            audio3.Play();
            mesh.enabled = true;
            terrain.enabled = true;
            mCollider.enabled = true;
        }
    }
}
