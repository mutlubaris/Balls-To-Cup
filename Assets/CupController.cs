using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class CupController : MonoBehaviour
{
    [SerializeField] private float _sensitivity;
    [SerializeField] private MeshFilter _bodyMeshFilter;
    [SerializeField] private Transform _bodyTrans;

    private Vector3 _clickPosition;

    private void Start()
    {
        var oldPos = transform.position;
        transform.position = new Vector3(transform.position.x, _bodyMeshFilter.mesh.bounds.center.y, transform.position.z);
        _bodyTrans.localPosition += Vector3.up * (oldPos.y - _bodyMeshFilter.mesh.bounds.center.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickPosition = Input.mousePosition;
            print("Obj Pos: " + Camera.main.WorldToScreenPoint(transform.position));
            print("Click Pos: " + _clickPosition);
        }

        if (Input.GetMouseButton(0))
        {
            
        }
    }
}
