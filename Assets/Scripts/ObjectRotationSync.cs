using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotationSync : MonoBehaviour
{
    // Referens till objekt A
    [SerializeField] private Transform objectA;

    // Referens till objekt B
    [SerializeField] private Transform objectB;

    // Faktor för hur snabbt objekt B ska rotera relativt objekt A
    [SerializeField] private float rotationSpeedFactor = 1.0f;

    void Update()
    {
        if (objectA != null && objectB != null)
        {
            // Hämta rotationen på objekt A
            Vector3 rotationA = objectA.eulerAngles;

            // Applicera en modifierad rotation på objekt B
            objectB.eulerAngles = new Vector3(
                rotationA.x * rotationSpeedFactor,
                rotationA.y * rotationSpeedFactor,
                rotationA.z * rotationSpeedFactor
            );
        }
    }
}
