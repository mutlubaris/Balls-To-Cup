using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BallType", menuName = "BallType")]
public class BallType : ScriptableObject
{
    public Material ColorMaterial;
    public PhysicMaterial PhysicMaterial;
}
