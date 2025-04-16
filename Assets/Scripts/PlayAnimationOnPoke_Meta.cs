using UnityEngine;
using Oculus.Interaction;

[RequireComponent(typeof(Animator))]
public class PlayAnimationOnPoke_Meta : MonoBehaviour
{
    [SerializeField]
    private string animationTriggerName = "Play"; // Namnet på triggern i Animatorn

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Denna metod kallas via InteractableUnityEventWrapper → When Select
    public void OnPoked()
    {
        if (animator != null)
        {
            animator.SetTrigger(animationTriggerName);
            Debug.Log("Poke registered: Triggering animation.");
        }
        else
        {
            Debug.LogWarning("Animator saknas!");
        }
    }
}


