using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePortal : MonoBehaviour
{
    public MeshRenderer mesh;
    public MeshCollider mCollider;
    public Terrain terrain;
    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(score == 3) 
        {
            mesh.enabled = true;
            terrain.enabled = true;
            mCollider.enabled = true;
        }
    }
}
