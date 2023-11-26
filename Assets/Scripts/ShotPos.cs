using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPos : MonoBehaviour
{
    public Transform cameraPosition;

    private void FixedUpdate()
    {
        transform.position = cameraPosition.transform.position + cameraPosition.transform.forward * 0.5f;
    }

}
