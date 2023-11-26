using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomFactor = 0.6f;
    public float minFOV = 40f;
    public float zoomSpeed = 1f;
    private float defaultFOV = 60f;
    private float currentFOV;
    private Camera playerCamera;

    void Start()
    {
        playerCamera = GetComponent<Camera>();
        currentFOV = playerCamera.fieldOfView;
    }

    void Update()
    {
        // If the left mouse button is held, zoom in.
        if (Input.GetMouseButton(0))
        {
            // Calculate the new FOV.
            float newFOV = currentFOV * zoomFactor;

            // Clamp the new FOV to the min and max zoom.
            newFOV = Mathf.Clamp(newFOV, minFOV, defaultFOV);

            // Smoothly zoom the camera to the new FOV.
            playerCamera.fieldOfView = Mathf.Lerp(currentFOV, newFOV, zoomSpeed * Time.deltaTime);

            // Update the current FOV.
            currentFOV = playerCamera.fieldOfView;
        }
        else
        {
            // Instantly zoom back out to the original FOV.
            playerCamera.fieldOfView = defaultFOV;
            currentFOV = playerCamera.fieldOfView;
        }
    }
}
