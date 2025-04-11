using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationDialLockControl : MonoBehaviour
{
    private int[] result, correctCombination;

    private void Start()
    {
        result = new int[] {2,2,2,2}; // Initial "combination" of glyphs corresponding to numbers on clues.
        
        correctCombination = new int[] {1,3,5,0};

        DialRotate.Rotated += CheckResults; // Subscribed to the Rotated event in a separate script.
    }

    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "CombinationDial_1":
                result[0] = number; break;

            case "CombinationDial_2":
                result[1] = number; break;

            case "CombinationDial_3":
                result[2] = number; break;
            
            case "CombinationDial_4":
                result[3] = number; break;


        }

        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2] && result[3] == correctCombination[3])
        {
            Debug.Log("Opened!");
        }
    }

    private void OnDestroy()
    {
        DialRotate.Rotated -= CheckResults; // Unsubscribing to the Rotate event in a separate script.
    }
}
