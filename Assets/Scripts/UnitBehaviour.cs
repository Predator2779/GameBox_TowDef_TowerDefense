using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviour : MonoBehaviour
{
    #region ����������

    [SerializeField] protected GameObject _target;
    [SerializeField] protected float _speed = 0.1f;
    [SerializeField] protected float _damage = 0.008f;
    [SerializeField] protected float _coef = 0.4f;
    [SerializeField] protected bool _permissionDamage = false;

    #endregion

    #region ������

    /// <summary>
    /// ����� Start.
    /// </summary>
    private void Start()
    {
        
    }

    /// <summary>
    /// ����� ������� ������ ������������.
    /// </summary>
    protected void Coefficient()
    {
        _coef = Random.Range(0.4f, 1.0f);
    }

    /// <summary>
    /// ������ ������� �����.
    /// </summary>
    protected void Scale()
    {       
        transform.localScale = new Vector3(0.2f * _coef, Random.Range(0.2f, 0.4f) * _coef, 0.2f * _coef);
    }

    /// <summary>
    /// ����� ������� ����� �����.
    /// </summary>
    protected void CalculateDamage()
    {
        _damage *= _coef;
    }

    /// <summary>
    /// ����� ������� �������� �����.
    /// </summary>
    protected void CalculateSpeed()
    {
        _speed *= _coef;
    }

    #endregion
}
