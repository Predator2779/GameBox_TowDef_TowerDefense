using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    /// <summary>
    /// Выход при нажатии Escape.
    /// </summary>
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            ExitApp();
    }

    /// <summary>
    /// Метод выхода из игры.
    /// </summary>
    public void ExitApp()
    {
        Application.Quit();
    }
}
