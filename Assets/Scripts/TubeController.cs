using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class TubeController : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 1;
    [SerializeField] private float _distanceMultiplier = 1;
    [SerializeField] private float _maxTorque = 10;

    private Vector3 _previousMousePos;
    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponentInChildren<Rigidbody>();
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
            rigid.MoveRotation(rigid.rotation * Quaternion.Euler(new Vector3(0, 0, Mathf.Clamp(-Vector3.Cross(vectorToPoint.normalized / Mathf.Pow(vectorToPoint.magnitude, _distanceMultiplier), normalVector).z, -_maxTorque, _maxTorque)) * Time.deltaTime * _sensitivity));
            _previousMousePos = Input.mousePosition;
        }
    }
}
