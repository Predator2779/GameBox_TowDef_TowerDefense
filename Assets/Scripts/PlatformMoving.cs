using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    [SerializeField] private float _speedPlatform = 0.25f;

    void Update()
    {
        transform.position = new Vector3(transform.position.x + _speedPlatform, transform.position.y, transform.position.z);
    }
}
