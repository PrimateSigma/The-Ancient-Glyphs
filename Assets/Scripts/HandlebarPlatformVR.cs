using UnityEngine;

public class HandlebarPlatformVR : MonoBehaviour
{
    [Header("Referenser")]
    public Transform handlebar;     // Ditt styre
    public Transform platform;      // Plattformen som ska r�ra sig

    [Header("Handlebar inst�llningar")]
    public float topY = 0.3f;       // Max Y-position p� styret (n�r den �r "uppe")
    public float bottomY = -0.2f;   // Min Y-position (n�r den �r "helt nere")

    [Header("Plattformsr�relse")]
    public float platformTravelDistance = 3.0f; // Hur l�ngt plattformen ska r�ra sig ner
    private Vector3 platformStartPos;

    void Start()
    {
        if (platform != null)
            platformStartPos = platform.position;
    }

    void Update()
    {
        if (handlebar == null || platform == null) return;

        // L�s av styrets lokala Y-position
        float currentY = Mathf.Clamp(handlebar.localPosition.y, bottomY, topY);

        // R�kna ut hur l�ngt ner styret �r (0 = uppe, 1 = helt nere)
        float pullAmount = Mathf.InverseLerp(topY, bottomY, currentY);

        // Flytta plattformen
        Vector3 targetPosition = platformStartPos - new Vector3(0, platformTravelDistance * pullAmount, 0);
        platform.position = targetPosition;
    }
}

