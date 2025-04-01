using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTheTemple : MonoBehaviour
{
    public void AcceptBtn()
    {
        SceneManager.LoadScene("The Ancient Glyphs");
    }
}
