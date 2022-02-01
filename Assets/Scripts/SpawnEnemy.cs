using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    #region Переменные

    [SerializeField] private GameObject _enemy;
    [SerializeField] private int _amount;
    [SerializeField] private float _height;
    [SerializeField] private float _radius;

    #endregion

    #region Методы.

    private void Start()
    {
        SpawnEn();
    }

    /// <summary>
    /// Метод Update.
    /// </summary>
    private void Update()
    {
        _radius = GetComponent<CapsuleCollider>().radius * transform.localScale.x;
        _height = transform.position.y;
    }
       
    /// <summary>
    /// Спаун врагов.
    /// </summary>
    private void SpawnEn()
    {
        for (int i = 1; i <= _amount; i++)
        {
         var _pos = new Vector3(Random.Range(transform.parent.position.x -_radius,transform.parent.position.x + _radius), _height, Random.Range(transform.parent.position.z - _radius, transform.parent.position.z + _radius));


         GameObject _enemies = Instantiate(_enemy, _pos, Quaternion.identity);
            _enemies.transform.SetParent(gameObject.transform.parent);               
            _enemies.GetComponent<Rigidbody>().mass = Random.Range(0.5f, 10);
        }

        Destroy(gameObject);
    }

    #endregion
}