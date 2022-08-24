using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    public Transform camHolder;

    float xRotation;
    float yRotation;
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(!PauseMenu.paused)
        {
            // get mouse input
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * PlayerPrefs.GetFloat("sens");
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * PlayerPrefs.GetFloat("sens");

            yRotation += mouseX;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            // rotate cam and orientation
            camHolder.rotation = Quaternion.Euler(xRotation, yRotation - 90, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation - 90, 0);
        }
    }

    /// <summary>
    /// Set camera field of view
    /// </summary>
    public void DoFov(float endValue)
    {
        if(!PauseMenu.paused)
        {
            GetComponent<Camera>().DOFieldOfView(endValue, 0.25f);
        }
    }

    /// <summary>
    /// Set camera tilt (useful for sway when moving)
    /// </summary>
    public void DoTilt(float zTilt)
    {
        if(!PauseMenu.paused)
        {
            transform.DOLocalRotate(new Vector3(0, 0, zTilt), 0.25f);
        }
    }
}