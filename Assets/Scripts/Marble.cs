using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : MonoBehaviour {
    public bool isOut = false;
    private bool isMoving = true;
    private Rigidbody rb;
    private float timer = 1f;
    public GameObject circle;

    //private void Awake()
    //{
    //    circle = GameObject.FindWithTag("invisibleCircle");
    //    Debug.Log(circle);
    //}

    private void Start() {
        rb = GetComponent<Rigidbody>();
        isMoving = true;
    }

    private void Update() {
        if (rb.velocity.magnitude > 0) {
            isMoving = true;
        } else {
            isMoving = false;
        }
    }

    private void FixedUpdate() {
        if (!isMoving && isOut) {
            timer -= Time.deltaTime;
            if (timer <= 0.0f) {
                Destroy(gameObject);
                //Debug.Log("Score!!");
            }
        }
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    Debug.Log(collision.gameObject);
    //}

    private void OnTriggerExit(Collider colliderInfo) {
        ///Debug.Log(colliderInfo.gameObject);

        if (colliderInfo.gameObject.CompareTag("Circle")) {

            isOut = true;
        }

        //Debug.Log(isOut);
    }

}
