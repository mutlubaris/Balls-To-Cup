using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTriggerController : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Ball")
        {
            var ballStatusTracker = other.GetComponentInParent<BallStatusTracker>();
            if (ballStatusTracker.BallTransforms.Contains(other.transform)) 
            {
                ballStatusTracker.UpdateBallStatus(other.transform);
            }
        }
    }
}
