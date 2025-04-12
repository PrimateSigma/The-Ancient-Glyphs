using UnityEngine;

public class HandlebarYRotationTrigger : MonoBehaviour
{
    public Transform handlebar;
    public Transform platform;

    public float triggerAngleY = -30f; // När Y-vinkeln går under detta, trigga
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

        // Läs Y-rotation och konvertera till [-180, 180]
        float angleY = handlebar.localEulerAngles.y;
        if (angleY > 180f) angleY -= 360f;

        Debug.Log("Y-vinkel: " + angleY);

        if (!hasTriggered && angleY <= triggerAngleY)
        {
            hasTriggered = true;
            Debug.Log("TRIGGA FALL!");
        }

        if (hasTriggered)
        {
            platform.position = Vector3.MoveTowards(platform.position, targetPos, fallSpeed * Time.deltaTime);
        }
    }
}
