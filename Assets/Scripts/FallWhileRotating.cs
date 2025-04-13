using UnityEngine;

public class FallWhileRotating : MonoBehaviour
{
    [Header("Rotationsobjektet")]
    public Transform rotatingObject;

    [Header("F�ljande objekt")]
    public Transform fallingObject;

    [Header("Fallinst�llningar")]
    public float startY = 1f;
    public float endY = 0f;
    public float fallSpeed = 1f;

    private Quaternion previousRotation;
    private float currentY;

    void Start()
    {
        if (rotatingObject == null || fallingObject == null)
        {
            Debug.LogWarning("Gl�m inte att s�tta referenserna!");
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

        // Kolla om rotationen har �ndrats
        bool isRotating = Quaternion.Angle(previousRotation, rotatingObject.rotation) > 0.01f;
        previousRotation = rotatingObject.rotation;

        if (isRotating && currentY > endY)
        {
            currentY -= fallSpeed * Time.deltaTime;
            currentY = Mathf.Max(currentY, endY); // Begr�nsa s� den inte g�r f�r l�ngt
            fallingObject.position = new Vector3(fallingObject.position.x, currentY, fallingObject.position.z);
        }
    }
}
