using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagersBehaviour : UnitBehaviour
{
    [SerializeField] private HitPoints _hp;

    /// <summary>
    /// Метод Start.
    /// </summary>
    private void Start()
    {
        Coefficient();
        Scale();
        CalculateDamage();
        CalculateSpeed();
        Targeting();
    }

    /// <summary>
    /// Метод FixedUpdate.
    /// </summary>
    private void FixedUpdate()
    {
        Moving();
        Damaging();
    }

    /// <summary>
    /// Движение юнита к цели.
    /// </summary>
    private void Moving()
    {
        var _targetPos = new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z);

        transform.LookAt(_targetPos);
        transform.Translate(Vector3.Normalize(_target.transform.position - transform.position) * Time.deltaTime * _speed);
    }

    /// <summary>
    /// Метод расчета цели юнита.
    /// </summary>
    private void Targeting()
    {
        _target = GameObject.Find("Tower");
    }

    /// <summary>
    /// Метод нанесения урона.
    /// </summary>
    private void Damaging()
    {
        if (_permissionDamage)
            _hp._hitPoints -= _damage;
    }

    /// <summary>
    /// Проверка на наличия скрипта WallHP. И разрешение на нанесение урона.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            _hp = collision.gameObject.GetComponent<HitPoints>();
            _permissionDamage = true;
        }
    }

    /// <summary>
    /// Снятие разрешения.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 7)
            _permissionDamage = false;
    }
}
