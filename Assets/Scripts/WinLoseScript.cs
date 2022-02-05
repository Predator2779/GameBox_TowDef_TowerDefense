using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLoseScript : MonoBehaviour
{
    #region Перемееные

    [SerializeField] private GameObject _tower;
    [SerializeField] private GameObject _loseMenu;
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private GameObject _gameObjs;
    [SerializeField] private bool _death = false;

    #endregion

    #region Методы

    /// <summary>
    /// Метод Update.
    /// </summary>
    void Update()
    {
        Death();
        WinLose();
    }

    /// <summary>
    /// Победа при достижении точки.
    /// </summary>
    /// <param name="other">Платформа</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other == _tower)
            _death = true;
    }

    /// <summary>
    /// Поражение при уничтожении башни.
    /// </summary>
    private void Death()
    {
        _tower = GameObject.Find("Tower");

        if (_tower == null)
            _death = true;
    }

    /// <summary>
    /// Управление UI.
    /// </summary>
    private void WinLose()
    {
        if (_death)
        {
            if (_tower == null)
            {
                _loseMenu.gameObject.SetActive(true);
                _gameObjs.SetActive(false);
            }
            else
            {
                _winMenu.gameObject.SetActive(true);
                _gameObjs.SetActive(false);
            }
        }
    }

    #endregion
}
