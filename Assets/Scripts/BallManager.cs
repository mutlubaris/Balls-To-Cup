using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private BallType[] ballTypes;

    [HideInInspector] public List<Transform> BallTransforms= new List<Transform>();

    private void Start()
    {
        var childTransforms = GetComponentInChildren<Transform>();
        foreach (Transform childTransform in childTransforms)
        {
            if (childTransform.tag == "Ball") BallTransforms.Add(childTransform);
            int ballTypeIndex = Random.Range(0, BallTransforms.Count);
            childTransform.GetComponent<Renderer>().material = ballTypes[ballTypeIndex].ColorMaterial;
            childTransform.GetComponent<Collider>().material = ballTypes[ballTypeIndex].PhysicMaterial;
        }
    }

    public void UpdateBallStatus(Transform ballTransform)
    {
        BallTransforms.Remove(ballTransform);
        if (BallTransforms.Count == 0 ) 
        {
            print("GG");
        }
    }
}
