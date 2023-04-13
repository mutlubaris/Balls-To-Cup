using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class TubeController : MonoBehaviour
{
    [SerializeField] private SensitivityController _sensitivityController;

    private Vector3 _previousMousePos;
    private Rigidbody _rigid;

    private void Start()
    {
        _rigid = GetComponentInChildren<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _previousMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 vectorToPoint = _previousMousePos - Camera.main.WorldToScreenPoint(transform.position);
            Vector3 normalVector = Input.mousePosition - _previousMousePos;

            float rotationSpeed = -Vector3.Cross(vectorToPoint.normalized / vectorToPoint.magnitude, normalVector).z;

            _rigid.MoveRotation(_rigid.rotation * Quaternion.Euler(new Vector3(0, 0, Mathf.Clamp(rotationSpeed, -_sensitivityController.maxRotationSpeed, _sensitivityController.maxRotationSpeed))
                * Time.deltaTime * _sensitivityController.rotationSensitivity * 5000));

            _previousMousePos = Input.mousePosition;
        }
    }
}
