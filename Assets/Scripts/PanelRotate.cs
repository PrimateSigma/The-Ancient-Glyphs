using UnityEngine;

public class PanelRotate : MonoBehaviour
{
    public Transform[] snapPoints;
    public GameObject[] snappableObjects;
    public Animator targetAnimator;

    private void Update()
    {
        if (AllObjectsSnapped())
        {
            targetAnimator.SetTrigger("PlayAnimation"); // Triggar animationen
        }
    }

    private bool AllObjectsSnapped()
    {
        for (int i = 0; i < snappableObjects.Length; i++)
        {
            float distance = Vector3.Distance(snappableObjects[i].transform.position, snapPoints[i].position);
            if (distance > 0.05f) // Om objektet inte �r n�ra sin snap-punkt
            {
                return false;
            }
        }
        return true;
    }
}
