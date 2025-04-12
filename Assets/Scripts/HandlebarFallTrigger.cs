using UnityEngine;

public class HandlebarFallTrigger : MonoBehaviour
{
    public Transform handlebar;       // Din spak
    public Transform platform;        // Plattformen som ska falla
    public float triggerAngleZ = -60f; // När Z-vinkeln är <= detta, trigga
    public float fallDistance = 3f;    // Hur långt plattformen faller
    public float fallSpeed = 2f;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool hasTriggered = false;

    void Start()
    {
        if (platform != null)
        {
            startPos = platform.position;
            targetPos = startPos - new Vector3(0, fallDistance, 0);
        }
    }

    void Update()
    {
        if (handlebar == null || platform == null) return;

        // Läs Z-rotation (pga "Forward" axis)
        float zAngle = handlebar.localEulerAngles.z;
        if (zAngle > 180f) zAngle -= 360f;

        // Debug för att se vad som händer
        Debug.Log("Z-rotation: " + zAngle);

        // Trigga om spaken är neddragen förbi gränsen
        if (!hasTriggered && zAngle <= triggerAngleZ)
        {
            hasTriggered = true;
            Debug.Log("👉 Spak neddragen – Plattformen faller!");
        }

        // Flytta plattformen
        if (hasTriggered)
        {
            platform.position = Vector3.MoveTowards(platform.position, targetPos, fallSpeed * Time.deltaTime);
        }
    }
}

