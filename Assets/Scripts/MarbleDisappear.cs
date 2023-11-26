using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleDisappear : MonoBehaviour
{
    private bool isMoving = true;
    private Rigidbody rb;
    private float timer = 3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isMoving = true;
    }

    private void Update()
    {
        if (rb.velocity.magnitude > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    private void FixedUpdate()
    {
        if (!isMoving)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f) Destroy(gameObject);
        }
    }
}
