using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePortal : MonoBehaviour
{
    public Transform player;
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
        if((player.transform.position - this.transform.position).sqrMagnitude < 500)
        {
            if(score == 0) 
            {
                mesh.enabled = true;
                terrain.enabled = true;
                mCollider.enabled = true;
            }
        }
    }
}
