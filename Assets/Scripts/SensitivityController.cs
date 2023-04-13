using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sensitivity", menuName = "Sensitivity")]
public class SensitivityController : ScriptableObject
{
    public int rotationSensitivity = 6;
    public float maxRotationSpeed = 10;
}
