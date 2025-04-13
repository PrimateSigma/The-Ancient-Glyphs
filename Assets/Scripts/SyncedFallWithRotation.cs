using UnityEngine;

public class SyncedFallWithRotation : MonoBehaviour
{
    [Header("Rotationsobjektet")]
    public Transform rotatingObject;

    [Header("F�ljande objekt")]
    public Transform fallingObject;

    [Header("Inst�llningar")]
    public float maxRotation = 90f; // Max rotation i grader
    public float startY = 1f; // Startposition i Y-led
    public float endY = 0f;   // Slutposition i Y-led (hur l�ngt det faller)

    private Quaternion initialRotation;

    void Start()
    {
        if (rotatingObject != null)
            initialRotation = rotatingObject.rotation;

        if (fallingObject != null)
            fallingObject.position = new Vector3(fallingObject.position.x, startY, fallingObject.position.z);
    }

    void Update()
    {
        if (rotatingObject == null || fallingObject == null)
            return;

        // R�kna ut hur mycket objektet har roterat
        float currentAngle = Quaternion.Angle(initialRotation, rotatingObject.rotation);
        float t = Mathf.Clamp01(currentAngle / maxRotation); // Normalisera 0�1

        // Interpolera Y-position baserat p� rotation
        float newY = Mathf.Lerp(startY, endY, t);
        fallingObject.position = new Vector3(fallingObject.position.x, newY, fallingObject.position.z);
    }
}

