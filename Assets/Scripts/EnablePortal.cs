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
    public static int score = 0;
    private bool playOnce1 = true;
    private bool playOnce2 = true;
    private bool playOnce3 = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            score += 1;
        }
        if(score == 1)
        {
            left.GetComponent<MeshRenderer>().material = mat;
            if(playOnce1)
            {
                audio1.Play();
                playOnce1 = false;
            }
        }

        if(score == 2)
        {
            middle.GetComponent<MeshRenderer>().material = mat;
            if(playOnce2)
            {
                audio2.Play();
                playOnce2 = false;
            }
        }

        if(score == 3) 
        {
            right.GetComponent<MeshRenderer>().material = mat;
            if(playOnce3)
            {
                audio3.Play();
                playOnce3 = false;
            }
            mesh.enabled = true;
            terrain.enabled = true;
            mCollider.enabled = true;
        }
    }
}
