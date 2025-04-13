using UnityEngine;

public class SyncedFallWithSmoothFollow : MonoBehaviour
{
    [Header("Rotationsobjektet")]
    public Transform rotatingObject;

    [Header("Följande objekt")]
    public Transform fallingObject;

    [Header("Inställningar")]
    public float maxRotation = 90f;
    public float startY = 1f;
    public float endY = 0f;
    public float followSpeed = 2f; // Justera för långsammare eller snabbare rörelse

    private Quaternion initialRotation;
    private float currentY;

    void Start()
    {
        if (rotatingObject != null)
            initialRotation = rotatingObject.rotation;

        currentY = startY;

        if (fallingObject != null)
            fallingObject.position = new Vector3(fallingObject.position.x, currentY, fallingObject.position.z);
    }

    void Update()
    {
        if (rotatingObject == null || fallingObject == null)
            return;

        float currentAngle = Quaternion.Angle(initialRotation, rotatingObject.rotation);
        float t = Mathf.Clamp01(currentAngle / maxRotation);
        float targetY = Mathf.Lerp(startY, endY, t);

        // Mjuk rörelse mot targetY
        currentY = Mathf.Lerp(currentY, targetY, Time.deltaTime * followSpeed);
        fallingObject.position = new Vector3(fallingObject.position.x, currentY, fallingObject.position.z);
    }
}
