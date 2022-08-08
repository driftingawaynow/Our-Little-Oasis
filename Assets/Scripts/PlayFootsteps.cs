using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootsteps : MonoBehaviour
{
    public AudioClip[] sandClips;
    public AudioClip[] rockClips;
    public AudioClip[] tileClips;
    public AudioClip[] wallClips;
    public AudioSource audioSource;
    private RaycastHit hit;
    private string floorTag;
    private float audioTimer = 0.0f;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            floorTag = hit.collider.tag;
            //Debug.Log(floorTag);
        }
        //Debug.Log(PlayerMovementAdvanced.state);
        if(PlayerMovementAdvanced.state.ToString() == "walking" && rb.velocity.magnitude > 2)
        {
            switch(floorTag)
            {
                case "Sand":
                    playFootsteps(sandClips, 0.6f);
                    break;
                case "Rock":
                    playFootsteps(rockClips, 0.6f);
                    break;
                case "Tile":
                    playFootsteps(tileClips, 0.6f);
                    break;
            }
        }
        if(PlayerMovementAdvanced.state.ToString() == "sprinting")
        {
            switch(floorTag)
            {
                case "Sand":
                    playFootsteps(sandClips, 0.4f);
                    break;
                case "Rock":
                    playFootsteps(rockClips, 0.4f);
                    break;
                case "Tile":
                    playFootsteps(tileClips, 0.4f);
                    break;
            }
        }
        if(WallJump.isWallJumping)
        {
            playFootsteps(wallClips, 0.5f);
            WallJump.isWallJumping = false;
        }
        audioTimer += Time.deltaTime;
    }

    void playFootsteps(AudioClip[] clips, float audioSpeed)
    {
        int r = Random.Range(0, clips.Length);
        AudioClip clip = clips[r];
        if(audioTimer >= audioSpeed)
        {
            audioSource.clip = clip;
            audioSource.Play();
            audioTimer = 0.0f;
        }
    }
}
