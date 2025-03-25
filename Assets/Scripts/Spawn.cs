using UnityEngine;

public class Spawn : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TriggerZone>().OnEnterEvent.AddListener(InsideZone);
    }
    public void InsideZone(GameObject go)
    {
        go.SetActive(true);
    }
}
