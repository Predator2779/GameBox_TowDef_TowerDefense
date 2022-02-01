using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoints : MonoBehaviour
{
    #region ����������

    [SerializeField] public float _hitPoints;

    #endregion

    #region ������

    /// <summary>
    /// ����� Update.
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
