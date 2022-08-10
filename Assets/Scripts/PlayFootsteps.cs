using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootsteps : MonoBehaviour
{
    public AudioClip[] sandClips;
    public AudioClip[] rockClips;
    public AudioClip[] tileClips;
    public AudioClip[] wallClips;
    public AudioClip[] waterClips;
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
        //Debug.Log(onWater);
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
                    audioSource.volume = 1f;
                    playFootsteps(sandClips, 0.6f);
                    break;
                case "Rock":
                    audioSource.volume = 1f;
                    playFootsteps(rockClips, 0.6f);
                    break;
                case "Tile":
                    audioSource.volume = 1f;
                    playFootsteps(tileClips, 0.6f);
                    break;
                case "Water":
                    audioSource.volume = 0.5f;
                    playFootsteps(waterClips, 0.6f);
                    break;
            }
        }
        if(PlayerMovementAdvanced.state.ToString() == "sprinting")
        {
            switch(floorTag)
            {
                case "Sand":
                    audioSource.volume = 1f;
                    playFootsteps(sandClips, 0.4f);
                    break;
                case "Rock":
                    audioSource.volume = 1f;
                    playFootsteps(rockClips, 0.4f);
                    break;
                case "Tile":
                    audioSource.volume = 1f;
                    playFootsteps(tileClips, 0.4f);
                    break;
                case "Water":
                    audioSource.volume = 0.5f;
                    playFootsteps(waterClips, 0.4f);
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
