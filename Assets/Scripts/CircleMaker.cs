using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMaker : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private int count = 361;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = count;

        for (int i = 0; i < count; i++)
        {
            float angle = i * Mathf.PI * 2 / 360;
            Vector3 position = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
            lineRenderer.SetPosition(i, position);
        }
    }
}
