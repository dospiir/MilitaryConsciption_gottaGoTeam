using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    public Collider2D mapBounds;
    public CinemachineVirtualCamera virtualCamera;

    private void LateUpdate()
    {
        Vector3 cameraPosition = virtualCamera.transform.position;
        Vector3 clampedPosition = mapBounds.ClosestPoint(cameraPosition);

        if (clampedPosition != cameraPosition)
        {
            virtualCamera.transform.position = clampedPosition;
        }
    }
}

