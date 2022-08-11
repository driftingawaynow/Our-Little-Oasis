using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePortalMenu : MonoBehaviour
{
    public Transform player;
    public MeshRenderer mesh;
    public MeshCollider mCollider;
    public Terrain terrain;
    public Renderer left;
    public Renderer middle;
    public Renderer right;
    public Material mat;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("EndScreen"))
        {
            PlayerPrefs.SetInt("EndScreen", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("EndScreen") == 1) 
        {
            left.GetComponent<MeshRenderer>().material = mat;
            middle.GetComponent<MeshRenderer>().material = mat;
            right.GetComponent<MeshRenderer>().material = mat;

            mesh.enabled = true;
            terrain.enabled = true;
            mCollider.enabled = true;
        }
    }
}
