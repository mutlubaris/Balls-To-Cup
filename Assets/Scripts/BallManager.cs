using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallManager : MonoBehaviour
{
    [SerializeField] private BallType[] ballTypes;

    [HideInInspector] public List<Transform> BallTransforms= new List<Transform>();

    private int numberOfBalls;

    private void Start()
    {
        var childTransforms = GetComponentInChildren<Transform>();
        foreach (Transform childTransform in childTransforms)
        {
            if (childTransform.tag == "Ball") BallTransforms.Add(childTransform);
            int ballTypeIndex = Random.Range(0, ballTypes.Length);
            childTransform.GetComponent<MeshRenderer>().material = ballTypes[ballTypeIndex].ColorMaterial;
            childTransform.GetComponent<Collider>().material = ballTypes[ballTypeIndex].PhysicMaterial;
        }
        numberOfBalls = BallTransforms.Count;
    }

    public void UpdateBallStatus(Transform ballTransform)
    {
        BallTransforms.Remove(ballTransform);
        if (BallTransforms.Count == 0 ) 
        {
            EventManager.OnAllBallsThrown.Invoke(numberOfBalls);
        }
    }
}
