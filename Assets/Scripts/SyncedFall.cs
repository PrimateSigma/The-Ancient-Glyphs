using UnityEngine;

public class SyncedFall : MonoBehaviour
{
    public Transform roteratObjekt;     // Det objekt som roteras (t.ex. en spak)
    public Transform fallandeObjekt;    // Det objekt som ska falla
    public float fallHastighet = 1.0f;  // Hur snabbt det faller
    public float stoppY = 1;         // Y-position där det ska stanna
    public bool aktiverad = false;      // Om rörelsen är igång

    private bool låst = false;

    void Update()
    {
        if (aktiverad && !låst)
        {
            // Enkel fallrörelse, kan modifieras till att följa rotationen mer exakt
            if (fallandeObjekt.position.y > stoppY)
            {
                fallandeObjekt.position -= new Vector3(0, fallHastighet * Time.deltaTime, 0);

                // Synca lite extra med rotationen (valfritt)
                fallandeObjekt.rotation = roteratObjekt.rotation;
            }
            else
            {
                // Stanna och lås objektet
                Vector3 pos = fallandeObjekt.position;
                pos.y = stoppY;
                fallandeObjekt.position = pos;

                låst = true;
            }
        }
    }
}

