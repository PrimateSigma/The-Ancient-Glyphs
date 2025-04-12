using UnityEngine;

public class HandlebarZRotationTrigger : MonoBehaviour
{
    public Transform handlebar;
    public Transform platform;

    [Header("Triggerinställningar")]
    public float triggerAngleZ = -30f; // T.ex. när du roterar spaken nedåt till -30 grader
    public float fallDistance = 3f;
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

        float angleZ = handlebar.localEulerAngles.z;
        if (angleZ > 180f) angleZ -= 360f;

        Debug.Log("Z-vinkel (spakrotation): " + angleZ);

        if (!hasTriggered && angleZ <= triggerAngleZ)
        {
            hasTriggered = true;
            Debug.Log("TRIGGER: Plattformen faller!");
        }

        if (hasTriggered)
        {
            platform.position = Vector3.MoveTowards(platform.position, targetPos, fallSpeed * Time.deltaTime);
        }
    }
}
