using UnityEngine;

public class FallWhileRotating : MonoBehaviour
{
    [Header("Rotationsobjektet")]
    public Transform rotatingObject;

    [Header("Följande objekt")]
    public Transform fallingObject;

    [Header("Fallinställningar")]
    public float startY = 1f;
    public float endY = 0f;
    public float fallSpeed = 1f;

    private Quaternion previousRotation;
    private float currentY;

    void Start()
    {
        if (rotatingObject == null || fallingObject == null)
        {
            Debug.LogWarning("Glöm inte att sätta referenserna!");
            return;
        }

        previousRotation = rotatingObject.rotation;
        currentY = startY;
        fallingObject.position = new Vector3(fallingObject.position.x, currentY, fallingObject.position.z);
    }

    void Update()
    {
        if (rotatingObject == null || fallingObject == null)
            return;

        // Kolla om rotationen har ändrats
        bool isRotating = Quaternion.Angle(previousRotation, rotatingObject.rotation) > 0.01f;
        previousRotation = rotatingObject.rotation;

        if (isRotating && currentY > endY)
        {
            currentY -= fallSpeed * Time.deltaTime;
            currentY = Mathf.Max(currentY, endY); // Begränsa så den inte går för långt
            fallingObject.position = new Vector3(fallingObject.position.x, currentY, fallingObject.position.z);
        }
    }
}
