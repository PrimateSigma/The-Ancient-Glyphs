using UnityEngine;

public class RotateAndFall : MonoBehaviour
{
    public Transform triggerObject;            // Objektet som roteras
    public GameObject fallingObject;           // Objektet som ska falla
    public float fallSpeedMultiplier = 2.0f;   // Hur snabbt objektet faller i relation till rotationens hastighet
    public float maxFallSpeed = 10f;           // Maximal fallhastighet
    public float stopYPosition = 1.0f;         // Y-position där objektet stannar

    private Rigidbody rb;
    private bool isFalling = false;

    private Vector3 lastRotation;

    void Start()
    {
        rb = fallingObject.GetComponent<Rigidbody>();
        rb.isKinematic = true; // Starta stilla
        lastRotation = triggerObject.rotation.eulerAngles;
    }

    void Update()
    {
        // Få fram rotationen på X- och Y-axeln
        Vector3 currentRotation = triggerObject.rotation.eulerAngles;
        
        // Beräkna hur mycket objektet har roterat
        float rotationDelta = Mathf.Abs(currentRotation.z - lastRotation.z);
        if (rotationDelta > 180f) rotationDelta = 360f - rotationDelta; // Förhindra att rotationen går över 360 grader

        lastRotation = currentRotation;

        if (rotationDelta > 0f && !isFalling)
        {
            rb.isKinematic = false; // Släpp objektet för att börja falla
            isFalling = true;
        }

        // Beräkna fallhastigheten beroende på rotationshastigheten
        float fallSpeed = Mathf.Clamp(rotationDelta * fallSpeedMultiplier, 0, maxFallSpeed);
        rb.velocity = new Vector3(0, -fallSpeed, 0);

        // Stoppa objektet när det når den specificerade Y-positionen
        if (fallingObject.transform.position.y <= stopYPosition)
        {
            rb.velocity = Vector3.zero;    // Stoppa rörelsen
            Vector3 pos = fallingObject.transform.position;
            pos.y = stopYPosition;         // Sätt objektet på rätt Y-position
            fallingObject.transform.position = pos;
        }
    }
}

