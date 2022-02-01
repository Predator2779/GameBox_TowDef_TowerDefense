using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericalCam : MonoBehaviour
{
    #region Переменные

       public Transform _playObj;
       public Transform _cameraOrbit;
       public float _rotateSpeed = 8f;
       public float _distSpeed = 10f;

    #endregion

    private void Update()
    {      
        DistanceCam();
        MoveCam();
    }

    /// <summary>
    /// Метод изменения дистанции камеры.
    /// </summary>
    private void DistanceCam()
    {
        float dist = Input.GetAxis("Mouse ScrollWheel");

        if (dist != 0)
        {
            var _direction = transform.position - _playObj.position;
            transform.position += transform.forward * dist * _distSpeed;

            if (Vector3.Distance(transform.position, _playObj.position) <= 5)
                transform.position += -transform.forward * dist * _distSpeed;
        }
    }

    /// <summary>
    /// Метод перемещения камеры.
    /// </summary>
    private void MoveCam()
    {
        _cameraOrbit.transform.position = _playObj.position;
        transform.LookAt(_playObj.position);

        if (Input.GetMouseButton(1))
        {
            Cursor.visible = false;

            float h = _rotateSpeed * Input.GetAxis("Mouse X");
            float v = _rotateSpeed * Input.GetAxis("Mouse Y");

            if (_cameraOrbit.transform.eulerAngles.z + v <= 0.1f || _cameraOrbit.transform.eulerAngles.z + v >= 60.0f)
                v = 0;

            _cameraOrbit.transform.eulerAngles = new Vector3(_cameraOrbit.transform.eulerAngles.x, _cameraOrbit.transform.eulerAngles.y + h, _cameraOrbit.transform.eulerAngles.z + v);
        }
        else
            Cursor.visible = true;
    }
}
