using UnityEngine;

public class RotateAndDrop : MonoBehaviour
{
    public Transform fallingObject; // Dra objektet som ska falla hit i inspektorn
    public float fallSpeed = 2f; // Hur snabbt objektet faller
    public float rotationThreshold = 10f; // Hur mycket du måste rotera innan det börjar falla
    public float stopY = -2f; // Position i Y där det ska stanna

    private Quaternion initialRotation; // Startrotation
    private bool hasReachedBottom = false; // Om objektet har nått botten

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Om inget objekt är tilldelat eller om vi redan nått botten, gör ingenting
        if (fallingObject == null || hasReachedBottom)
            return;

        // Beräkna rotationsskillnaden
        float angleDifference = Quaternion.Angle(initialRotation, transform.rotation);

        // Om rotationsskillnaden är tillräckligt stor
        if (angleDifference > rotationThreshold)
        {
            // Om objektet är ovanför stopY, fortsätt sänka det
            if (fallingObject.position.y > stopY)
            {
                fallingObject.position += Vector3.down * fallSpeed * Time.deltaTime;
            }
            else
            {
                // Annars stanna exakt på stopY och markera som klar
                Vector3 pos = fallingObject.position;
                pos.y = stopY;
                fallingObject.position = pos;
                hasReachedBottom = true;
            }
        }
    }
}


