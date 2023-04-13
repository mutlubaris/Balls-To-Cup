using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallManager : MonoBehaviour
{
    [SerializeField] private BallType[] ballTypes;

    [HideInInspector] public List<Transform> ActiveBallTransforms= new List<Transform>();

    private int numberOfBalls;

    private void Start()
    {
        var childTransforms = GetComponentInChildren<Transform>();
        foreach (Transform childTransform in childTransforms)
        {
            if (childTransform.tag == "Ball") ActiveBallTransforms.Add(childTransform);
            int ballTypeIndex = Random.Range(0, ballTypes.Length);
            childTransform.GetComponent<MeshRenderer>().material = ballTypes[ballTypeIndex].ColorMaterial;
            childTransform.GetComponent<Collider>().material = ballTypes[ballTypeIndex].PhysicMaterial;
        }
        numberOfBalls = ActiveBallTransforms.Count;
    }

    public void UpdateBallStatus(Transform ballTransform)
    {
        ActiveBallTransforms.Remove(ballTransform);
        if (ActiveBallTransforms.Count == 0) 
        {
            EventManager.OnAllBallsThrown.Invoke(numberOfBalls);
        }
    }
}
