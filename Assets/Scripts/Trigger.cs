using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TriggerZone>().OnEnterEvent.AddListener(InsideTrash);
    }
    public void InsideTrash(GameObject go)
    {
        go.SetActive(false);
    }
}
