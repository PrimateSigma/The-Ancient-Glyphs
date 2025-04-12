using UnityEngine;

public class HandlebarRotationTrigger : MonoBehaviour
{
    public Transform handlebar;
    public Transform platform;

    public float triggerAngle = -50f; // När spaken lutar mer än detta, trigga
    public float fallDistance = 3f;
    public float fallSpeed = 2f;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool hasFallen = false;

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

        float angle = handlebar.localEulerAngles.x;
        if (angle > 180) angle -= 360; // Konvertera till [-180, 180]

        // Debug-logga för att se vinkeln i Play Mode
        Debug.Log("Handlebar vinkel X: " + angle);

        if (!hasFallen && angle <= triggerAngle)
        {
            hasFallen = true;
            Debug.Log("Spaken neddragen – Plattformen faller!");
        }

        if (hasFallen)
        {
            platform.position = Vector3.MoveTowards(platform.position, targetPos, fallSpeed * Time.deltaTime);
        }
    }
}


