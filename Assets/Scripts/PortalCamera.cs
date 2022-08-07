using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCam;
    public Transform portal;
    public Transform otherPortal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 p = transform.position;
        Vector3 playerOffsetFromPortal = playerCam.position - otherPortal.position;
        p = portal.position + playerOffsetFromPortal;
        p.y += 0.5f;
        transform.position = p;

        float portalAngularDifference = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion portalRotationDifference = Quaternion.AngleAxis(portalAngularDifference, Vector3.up);
        Vector3 newCameraDirection = portalRotationDifference * playerCam.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
