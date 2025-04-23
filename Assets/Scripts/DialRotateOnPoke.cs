using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialRotateOnPoke : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };

    bool _busy = false;
    int _number = 5;

    // Called via the WhenSelect UnityEvent
    public void RotateDial()
    {
        if (_busy) return;
        StartCoroutine(RotateWheel());
    }

    IEnumerator RotateWheel()
    {
        _busy = true;
        for (int i = 0; i < 6; i++)
        {
            transform.Rotate(10f, 0f, 0f);
            yield return new WaitForSeconds(0.01f);
        }

        _number = (_number + 1) % 6;
        Rotated(name, _number);
        _busy = false;
    }
}