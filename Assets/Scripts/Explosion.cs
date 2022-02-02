using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    #region Переменные

    [SerializeField] private HitPoints _hp;
    [SerializeField] public Vector3 _direction;
    [SerializeField] private float _forceExplosion = 10.0f;
    [SerializeField] private float _rocketSpeed = 0.6f;
    [SerializeField] private float _damage = 45.0f;
    [SerializeField] private bool _isDamaged = false;
    [SerializeField] private bool _fire = false;
    [SerializeField] private List<Rigidbody> objectsInCol = new List<Rigidbody>();

    #endregion


    #region Методы

    /// <summary>
    /// Метод Start.
    /// </summary>
    private void Start()
    {
        CalculateRocketDamage();
    }

    /// <summary>
    /// Метод FixedUpdate.
    /// </summary>
    private void FixedUpdate()
    {
        MovingRocket();
        Fire();
    }

    /// <summary>
    /// Метод столкновения.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        var body = other.GetComponent<Rigidbody>();
        _hp = body.GetComponent<HitPoints>();

        if (!objectsInCol.Contains(body))
            objectsInCol.Add(body);

        _fire = true;
    }

    /// <summary>
    /// Условие уничтожения ракеты.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
            Destroy(gameObject);
    }

    /// <summary>
    /// Движение ракеты.
    /// </summary>
    private void MovingRocket()
    {
        gameObject.transform.Translate(_direction.normalized * _rocketSpeed, Space.World);
    }

    /// <summary>
    /// Здесь прикладывается сила к объектам, попавшим в триггер.
    /// </summary>
    private void Fire()
    {
        if (_fire)
        {
            for (int i = 0; i < objectsInCol.Count; i++)
            {
                var _turPos = new Vector3(transform.position.x, -2.0f, transform.position.z);
                var _vector = objectsInCol[i].transform.localPosition - _turPos;
                objectsInCol[i].AddForce(_vector * _forceExplosion, ForceMode.Impulse);

                if (!_isDamaged && _hp)
                {
                    _hp._hitPoints -= _damage;
                    _isDamaged = true;
                }
            }
        }
    }

    /// <summary>
    /// Метод расчета урона ракеты.
    /// </summary>
    protected void CalculateRocketDamage()
    {
        _damage = Random.Range(45.0f, 100.0f);
    }

    #endregion
}
