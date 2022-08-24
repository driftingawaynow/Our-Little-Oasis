using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCam;
    public Camera playerCamera;
    public Camera otherCamera;
    public Transform portal;
    public Transform otherPortal;

    // Update is called once per frame
    void LateUpdate()
    {
        if(!PauseMenu.paused)
        {
            // set secondary camera to same transforms as primary
            otherCamera.fieldOfView = playerCamera.fieldOfView;
            this.transform.eulerAngles = playerCamera.transform.eulerAngles;
            Vector3 p = transform.position;
            // check player offset and adjust based on distance
            Vector3 playerOffsetFromPortal = playerCam.position - otherPortal.position;
            p = portal.position + playerOffsetFromPortal;
            transform.position = p;
        }
    }

    public void DoPortalTilt(float zTilt)
    {
        if(!PauseMenu.paused)
        {
            transform.DOLocalRotate(new Vector3(0, 0, zTilt), 0.25f);
        }
    }
}
