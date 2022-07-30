using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteActive : MonoBehaviour
{
    public Transform player;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if((player.transform.position - this.transform.position).sqrMagnitude < 100) // && Input.GetKeyDown(KeyCode.E))
        {
            anim.Play("Extend");
        }
    }
}
