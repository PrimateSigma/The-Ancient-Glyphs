using UnityEngine;

public class HandlebarXRotationTrigger : MonoBehaviour
{
    public Transform handlebar;       // Din spak
    public Transform platform;        // Plattformen som ska falla
    public float triggerAngleX = -60f; // När X-vinkeln är <= detta, trigga
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

        // Läs av X-rotation (pga "Forward" rotation axis)
        float xAngle = handlebar.localEulerAngles.x;

        // Om X-vinkeln går över 180 (eftersom Unity roterar 0-360) så konverterar vi den till negativ
        if (xAngle > 180f) xAngle -= 360f;

        // Debug-logga för att se vad som händer med vinkeln
        Debug.Log("X-vinkel (spakrotation): " + xAngle);

        // Trigga om spaken är neddragen förbi gränsen
        if (!hasTriggered && xAngle <= triggerAngleX)
        {
            hasTriggered = true;
            Debug.Log("Spaken neddragen – Plattformen börjar falla!");
        }

        // Flytta plattformen
        if (hasTriggered)
        {
            platform.position = Vector3.MoveTowards(platform.position, targetPos, fallSpeed * Time.deltaTime);
        }
    }
}

