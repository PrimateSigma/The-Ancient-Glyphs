using UnityEngine;

public class FollowFallOnRotate : MonoBehaviour
{
    [Header("Rotationsobjektet")]
    public Transform rotatingObject; // Objektet som roteras

    [Header("Följande objekt")]
    public Transform fallingObject; // Objektet som ska falla
    public float targetY = 0.0f; // Y-position där objektet ska stanna
    public float fallSpeed = 2.0f; // Hur snabbt objektet faller

    [Header("Rotation Trigger")]
    public float rotationThreshold = 15.0f; // Hur mycket man måste rotera innan objektet faller

    private bool hasFallen = false;
    private Quaternion initialRotation;

    void Start()
    {
        if (rotatingObject != null)
            initialRotation = rotatingObject.rotation;
    }

    void Update()
    {
        if (rotatingObject == null || fallingObject == null || hasFallen)
            return;

        float angle = Quaternion.Angle(initialRotation, rotatingObject.rotation);

        if (angle >= rotationThreshold)
        {
            // Starta fallet
            Vector3 currentPosition = fallingObject.position;
            float newY = Mathf.MoveTowards(currentPosition.y, targetY, fallSpeed * Time.deltaTime);
            fallingObject.position = new Vector3(currentPosition.x, newY, currentPosition.z);

            if (Mathf.Approximately(newY, targetY))
            {
                hasFallen = true;
            }
        }
    }
}

