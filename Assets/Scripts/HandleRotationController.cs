using UnityEngine;

public class HandleRotationController : MonoBehaviour
{
    [Header("Drag in handtaget här")]
    public Transform handle;

    [Header("Det objekt som ska följa rotationen")]
    public Transform targetObject;

    [Header("Rotation Axis")]
    public Vector3 rotationAxis = Vector3.up;

    [Header("Rotation Multiplier")]
    public float rotationMultiplier = 1f;

    private float initialHandleAngle;
    private float initialTargetAngle;

    void Start()
    {
        initialHandleAngle = Vector3.Dot(handle.localEulerAngles, rotationAxis);
        initialTargetAngle = Vector3.Dot(targetObject.localEulerAngles, rotationAxis);
    }

    void Update()
    {
        float currentHandleAngle = Vector3.Dot(handle.localEulerAngles, rotationAxis);
        float deltaAngle = Mathf.DeltaAngle(initialHandleAngle, currentHandleAngle);

        float newTargetAngle = initialTargetAngle + deltaAngle * rotationMultiplier;
        targetObject.localRotation = Quaternion.AngleAxis(newTargetAngle, rotationAxis);
    }
}

