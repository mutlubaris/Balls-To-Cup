using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTriggerController : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Ball")
        {
            var ballStatusTracker = other.GetComponentInParent<BallManager>();
            if (ballStatusTracker.activeBallTransforms.Contains(other.transform)) 
            {
                ballStatusTracker.UpdateBallStatus(other.transform);
            }
        }
    }
}
