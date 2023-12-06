using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public Transform playerMarble; // Reference to the player marble GameObject
    public Transform circleCenter; // Reference to the center of the circle GameObject

    public float followSpeed = 5f; // Speed at which the camera follows the marble
    public float inspectDuration = 3f; // Duration to inspect the impact

    private bool isInspecting = false;
    private Vector3 initialPosition;

    private void Start() {
        initialPosition = transform.position;
    }

    private void Update() {
        if (!isInspecting) {
            Vector3 targetPosition = playerMarble.position;
            // Adjust the camera's target position to follow the marble smoothly
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

    public void InspectImpact() {
        isInspecting = true;
        // Calculate a position to inspect (you might want to adjust this)
        Vector3 inspectionPosition = circleCenter.position + new Vector3(0f, 5f, -5f);
        StartCoroutine(InspectCoroutine(inspectionPosition));
    }

    private IEnumerator InspectCoroutine(Vector3 inspectionPosition) {
        float elapsedTime = 0f;

        while (elapsedTime < inspectDuration) {
            transform.position = Vector3.Lerp(transform.position, inspectionPosition, elapsedTime / inspectDuration);
            transform.LookAt(circleCenter.position);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Inspection time is over, return the camera to the initial position
        isInspecting = false;
        StartCoroutine(ReturnToPlayer());
    }

    private IEnumerator ReturnToPlayer() {
        float elapsedTime = 0f;
        Vector3 currentPos = transform.position;

        while (elapsedTime < inspectDuration) {
            transform.position = Vector3.Lerp(currentPos, initialPosition, elapsedTime / inspectDuration);
            transform.LookAt(playerMarble.position);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Camera returns to the player's marble
        isInspecting = false;
    }
}
