using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickQuit : MonoBehaviour
{
    void LateUpdate()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }
}
