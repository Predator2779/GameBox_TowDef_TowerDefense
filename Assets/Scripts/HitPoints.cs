using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoints : MonoBehaviour
{
    #region Переменные

    [SerializeField] public float _hitPoints;

    #endregion

    #region Методы

    /// <summary>
    /// Метод Update.
    /// </summary>
    private void Update()
    {
        Death();
    }

    private void Death()
    {
        if (_hitPoints < 0)
            Destroy(gameObject);
    }

    #endregion
}
