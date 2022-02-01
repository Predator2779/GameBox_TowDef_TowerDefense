using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTurrets : MonoBehaviour
{
    [SerializeField] private GameObject _obj;
    [SerializeField] private GameObject _spawn;
    [SerializeField] private bool _isSpawned = false;

    public void SpawnTur()
    {
        if (!_isSpawned)
        {
            GameObject _clone = Instantiate(_obj);
            _clone.transform.SetParent(_spawn.transform.parent);
            _clone.transform.position = _spawn.transform.position;
            _clone.transform.rotation = _spawn.transform.rotation;

            _isSpawned = true;
        }
    }
}
