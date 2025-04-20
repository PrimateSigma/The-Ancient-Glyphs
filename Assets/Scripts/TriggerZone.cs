using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] private string targetTag;
    [SerializeField] private Animator targetAnimator;
    public UnityEvent<GameObject> OnEnterEvent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == targetTag)
        {
            targetAnimator.SetTrigger("PlayAnimation");
            OnEnterEvent.Invoke(other.gameObject);            
        }
    }
}
