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
        if(!PlayerPrefs.HasKey("sens"))
        {
            PlayerPrefs.SetFloat("sens", 100);
        }
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

    public void DoFov(float endValue)
    {
        if(!PauseMenu.paused)
        {
            GetComponent<Camera>().DOFieldOfView(endValue, 0.25f);
        }
    }

    public void DoTilt(float zTilt)
    {
        if(!PauseMenu.paused)
        {
            transform.DOLocalRotate(new Vector3(0, 0, zTilt), 0.25f);
        }
    }
}