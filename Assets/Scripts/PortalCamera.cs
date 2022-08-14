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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!PauseMenu.paused)
        {
            otherCamera.fieldOfView = playerCamera.fieldOfView;
            this.transform.eulerAngles = playerCamera.transform.eulerAngles;
            Vector3 p = transform.position;
            Vector3 playerOffsetFromPortal = playerCam.position - otherPortal.position;
            p = portal.position + playerOffsetFromPortal;
            transform.position = p;

            //float portalAngularDifference = Quaternion.Angle(portal.rotation, otherPortal.rotation);
            //Quaternion portalRotationDifference = Quaternion.AngleAxis(portalAngularDifference, Vector3.up);
            //Vector3 newCameraDirection = portalRotationDifference * playerCam.forward;
            //transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
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
