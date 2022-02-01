using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    /// <summary>
    /// ����� ��� ������� Escape.
    /// </summary>
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            ExitApp();
    }

    /// <summary>
    /// ����� ������ �� ����.
    /// </summary>
    public void ExitApp()
    {
        Application.Quit();
    }
}
