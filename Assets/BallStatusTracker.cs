using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStatusTracker : MonoBehaviour
{
    public List<Transform> BallTransforms= new List<Transform>();

    private void Start()
    {
        var childTransforms = GetComponentInChildren<Transform>();
        foreach (Transform childTransform in childTransforms)
        {
            if (childTransform.tag == "Ball") BallTransforms.Add(childTransform);
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
