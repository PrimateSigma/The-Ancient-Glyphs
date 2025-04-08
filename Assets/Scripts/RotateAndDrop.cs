using UnityEngine;

public class RotateAndDrop : MonoBehaviour
{
    public Transform fallingObject; // Objektet som ska röra sig nedåt
    public float fallSpeed = 2f; // Hastighet för att sänka objektet

    private Quaternion lastRotation; // För att spåra föregående rotation

    void Start()
    {
        lastRotation = transform.rotation; // Spara startrotationen
    }

    void Update()
    {
        // Kontrollera om rotationen ändras
        if (transform.rotation != lastRotation)
        {
            // Få det fallande objektet att röra sig neråt
            if (fallingObject != null)
            {
                fallingObject.position += Vector3.down * fallSpeed * Time.deltaTime;
            }

            // Uppdatera senaste rotationen
            lastRotation = transform.rotation;
        }
    }
}



