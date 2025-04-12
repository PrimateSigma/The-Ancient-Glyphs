using UnityEngine;

public class RotationSyncFall : MonoBehaviour
{
    public Transform roteratObjekt;     // Objektet som roteras (ex. en arm eller spak)
    public Transform fallandeObjekt;    // Objektet som "faller" synkat
    public float fallHastighet = 1.5f;  // Hur snabbt det faller
    public float stoppY = 1;         // Y-position där det ska stanna
    public bool startaFall = false;     // Startar rörelsen

    private bool ärLåst = false;

    void Update()
    {
        if (startaFall && !ärLåst)
        {
            // Flytta objektet nedåt tills det når stoppY
            if (fallandeObjekt.position.y > stoppY)
            {
                fallandeObjekt.position -= new Vector3(0, fallHastighet * Time.deltaTime, 0);

                // Roterar fallande objektet i takt med det roterade objektet
                fallandeObjekt.rotation = roteratObjekt.rotation;
            }
            else
            {
                // Stanna exakt vid stoppY och lås rörelsen
                Vector3 pos = fallandeObjekt.position;
                pos.y = stoppY;
                fallandeObjekt.position = pos;
                ärLåst = true;
            }
        }
    }
}
