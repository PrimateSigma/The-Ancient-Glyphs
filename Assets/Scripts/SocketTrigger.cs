using UnityEngine;

public class SocketTrigger : MonoBehaviour
{
    [Tooltip("Det objekt som ska spela en animation")]
    public Animator targetAnimator;

    [Tooltip("Namnet på triggern i animatorn som ska spelas")]
    public string animationTriggerName = "PlayAnimation";

    [Tooltip("Tag på det objekt som ska trigga animationen")]
    public string targetTag = "Amulet";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log("Objekt placerat i socket – spelar animation.");
            targetAnimator.SetTrigger(animationTriggerName);
        }
    }
}

