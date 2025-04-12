using UnityEngine;

public class HandlebarPlatformVR : MonoBehaviour
{
    [Header("Referenser")]
    public Transform handlebar;     // Ditt styre
    public Transform platform;      // Plattformen som ska röra sig

    [Header("Handlebar inställningar")]
    public float topY = 0.3f;       // Max Y-position på styret (när den är "uppe")
    public float bottomY = -0.2f;   // Min Y-position (när den är "helt nere")

    [Header("Plattformsrörelse")]
    public float platformTravelDistance = 3.0f; // Hur långt plattformen ska röra sig ner
    private Vector3 platformStartPos;

    void Start()
    {
        if (platform != null)
            platformStartPos = platform.position;
    }

    void Update()
    {
        if (handlebar == null || platform == null) return;

        // Läs av styrets lokala Y-position
        float currentY = Mathf.Clamp(handlebar.localPosition.y, bottomY, topY);

        // Räkna ut hur långt ner styret är (0 = uppe, 1 = helt nere)
        float pullAmount = Mathf.InverseLerp(topY, bottomY, currentY);

        // Flytta plattformen
        Vector3 targetPosition = platformStartPos - new Vector3(0, platformTravelDistance * pullAmount, 0);
        platform.position = targetPosition;
    }
}

