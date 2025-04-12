using UnityEngine;

public class HandlebarXRotationTrigger : MonoBehaviour
{
    public Transform handlebar;       // Din spak
    public Transform platform;        // Plattformen som ska falla
    public float triggerAngleX = -60f; // N�r X-vinkeln �r <= detta, trigga
    public float fallDistance = 3f;    // Hur l�ngt plattformen faller
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

        // L�s av X-rotation (pga "Forward" rotation axis)
        float xAngle = handlebar.localEulerAngles.x;

        // Om X-vinkeln g�r �ver 180 (eftersom Unity roterar 0-360) s� konverterar vi den till negativ
        if (xAngle > 180f) xAngle -= 360f;

        // Debug-logga f�r att se vad som h�nder med vinkeln
        Debug.Log("X-vinkel (spakrotation): " + xAngle);

        // Trigga om spaken �r neddragen f�rbi gr�nsen
        if (!hasTriggered && xAngle <= triggerAngleX)
        {
            hasTriggered = true;
            Debug.Log("Spaken neddragen � Plattformen b�rjar falla!");
        }

        // Flytta plattformen
        if (hasTriggered)
        {
            platform.position = Vector3.MoveTowards(platform.position, targetPos, fallSpeed * Time.deltaTime);
        }
    }
}

