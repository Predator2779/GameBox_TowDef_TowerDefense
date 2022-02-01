using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsOff : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Off());
    }

    private IEnumerator Off()
    {
        yield return new WaitForSeconds(5f);

        gameObject.SetActive(false);
    }
}
