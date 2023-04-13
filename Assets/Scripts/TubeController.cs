using Sirenix.OdinInspector;
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

            _rigid.MoveRotation(_rigid.rotation * Quaternion.Euler(new Vector3(0, 0, Mathf.Clamp(-Vector3.Cross(vectorToPoint.normalized / 
                Mathf.Pow(vectorToPoint.magnitude, _sensitivityController.distanceSensitivity), normalVector).z, -_sensitivityController.maxTorque, _sensitivityController.maxTorque))
                * Time.deltaTime * _sensitivityController.rotateSensitivity));

            _previousMousePos = Input.mousePosition;
        }
    }
}
