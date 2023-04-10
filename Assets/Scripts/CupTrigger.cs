using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CupTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI quantityText;
    
    private List<Transform> collectedBallTransforms = new List<Transform>();
    private int collectedBallQuantity;

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
