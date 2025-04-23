using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DialRotate : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };

    private bool coroutineAllowed;
    private int numberShown;


    // Start is called before the first frame update
    void Start()
    {
        coroutineAllowed = true;
        numberShown = 5;
    }

    // Update is called once per frame
    public void OnMouseDown()
    {
        if (coroutineAllowed)
        {
            StartCoroutine("RotateWheel");
        }
    }

    private IEnumerator RotateWheel()
    {
        coroutineAllowed = false;

        for(int i = 0; i <= 5; i++)
        {
            transform.Rotate(10.0f, 0f, 0f);
            yield return new WaitForSeconds(0.01f);
        }

        coroutineAllowed=true;

        numberShown += 1;

        if (numberShown > 5)
        {
            numberShown = 0;
        }

        Rotated(name, numberShown);

    }

}
