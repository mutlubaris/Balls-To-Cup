using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sensitivity", menuName = "Sensitivity")]
public class SensitivityController : ScriptableObject
{
    public float rotateSensitivity = 1;
    public float distanceSensitivity = 1;
    public float maxTorque = 10;
}
