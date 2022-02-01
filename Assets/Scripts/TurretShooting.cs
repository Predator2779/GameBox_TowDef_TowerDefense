using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    #region ����������

    [SerializeField] private GameObject _headTurret;
    [SerializeField] private GameObject _rocket;
    [SerializeField] private GameObject _enemy = null;
    [SerializeField] private float _speedRotaionTurret = 1.0f;
    [SerializeField] private float _shootPeriod = 2.0f;
    [SerializeField] private float _timer = 0;
    [SerializeField] private int _stopRotation = 1;
    [SerializeField] private bool _timing = false;

    #endregion

    #region ������

    /// <summary>
    /// ����� Update.
    /// </summary>
    private void Update()
    {
        Rotation();
        yPos();
        turretPos();        
    }
    
    /// <summary>
    /// ����� FixedUpdate.
    /// </summary>
    private void FixedUpdate()
    {
        OnceShoot();
    }
    
    /// <summary>
    /// ����� �����������, ��� ������� ���� �������� � ����������.
    /// </summary>
    /// <param name="target"></param>
    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "Platform")
            _speedRotaionTurret *= -1;
    }
    
    /// <summary>
    /// �������� �� ������, �������� � ���� �������� ������.
    /// </summary>
    /// <param name="target">����</param>
    private void OnTriggerStay(Collider target)
    {
        if (target.gameObject.tag == "Enemy")
            _enemy = target.gameObject;

        if (_enemy != null)
        {
            _stopRotation = 0;
            gameObject.transform.parent.LookAt(_enemy.transform.position, transform.position);
            _headTurret.transform.LookAt(_enemy.transform.position, transform.position);
            _timing = true;
        }       
    }

    /// <summary>
    /// ������� ���� target, ��� ������ ����� �� ��������.
    /// </summary>
    /// <param name="target"></param>
    private void OnTriggerExit(Collider target)
    {
        if (target.gameObject.tag == "Enemy")
            _enemy = null;
    }

    /// <summary>
    /// ����� ������ ������ �������� � x ������.
    /// </summary>
    private void OnceShoot()
    {
        if (_timing)
        {
            _timer += Time.deltaTime;           

            if (_timer >= _shootPeriod)
            {
                Shooting();                
                _timing = false;
                _timer = 0;
            }            
        }        
    }
    
    /// <summary>
    /// ����� �������� ������.
    /// </summary>
    private void Shooting()
    {
        var _clone = Instantiate(_rocket);
        ///  � ����������, ��������� ����������� ������ ������.
        _clone.transform.SetParent(_headTurret.transform);     
        _clone.transform.position = _headTurret.transform.position;
        _clone.transform.rotation = _headTurret.transform.rotation;
    }
    
    /// <summary>
    /// �������� ������.
    /// </summary>
    private void Rotation()
    {
        gameObject.transform.parent.Rotate(0, _speedRotaionTurret * _stopRotation, 0);

        if (_enemy == null && _stopRotation == 0)
            _stopRotation = 1;
    }
    
    /// <summary>
    /// ���������� ������� ���� �������� ��� �����.
    /// </summary>
    private void yPos()
    {       
        if (gameObject.transform.position.y < 0)
            gameObject.transform.position = new Vector3(transform.position.x, 0.20f, transform.position.z);               
    }
    
    /// <summary>
    /// ���������� �������� ������ �� x,z (�����������).
    /// </summary>
    private void turretPos()
    {
        if (gameObject.transform.parent.rotation.x != 0 || gameObject.transform.parent.rotation.z != 0)
            gameObject.transform.parent.rotation = new Quaternion(0, gameObject.transform.parent.rotation.y, 0, gameObject.transform.parent.rotation.w);
    }

    #endregion
}
