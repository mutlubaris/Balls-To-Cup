using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTriggerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Ball" && !collectedBallTransforms.Contains(other.transform))
        {
            collectedBallTransforms.Add(other.transform);
            collectedBallQuantity++;
            quantityText.SetText(collectedBallQuantity.ToString() + " / 20");
        }
    }
}
