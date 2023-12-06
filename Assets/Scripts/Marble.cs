using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : MonoBehaviour {
    public bool isOut = false;
    private bool isMoving = true;
    private Rigidbody rb;
    private float timer = 1f;
    public GameObject circle;
    public GameObject floatingScore;


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
                Instantiate(floatingScore, transform.position, Quaternion.identity);
                ScoreManager.instance.AddScore();
                Destroy(gameObject);
            }
        }
    }


    private void OnTriggerExit(Collider colliderInfo) {
        if (colliderInfo.gameObject.CompareTag("Circle")) {

            isOut = true;
        }
    }

}
