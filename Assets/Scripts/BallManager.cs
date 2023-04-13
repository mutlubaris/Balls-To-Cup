using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallManager : MonoBehaviour
{
    [SerializeField] private BallType[] _ballTypes;

    [HideInInspector] public List<Transform> activeBallTransforms= new List<Transform>();

    private int numberOfBalls;

    private void Start()
    {
        var childTransforms = GetComponentInChildren<Transform>();
        foreach (Transform childTransform in childTransforms)
        {
            if (childTransform.tag == "Ball") activeBallTransforms.Add(childTransform);
            int ballTypeIndex = Random.Range(0, _ballTypes.Length);
            childTransform.GetComponent<MeshRenderer>().material = _ballTypes[ballTypeIndex].colorMaterial;
            childTransform.GetComponent<Collider>().material = _ballTypes[ballTypeIndex].physicMaterial;
        }
        numberOfBalls = activeBallTransforms.Count;
    }

    public void UpdateBallStatus(Transform ballTransform)
    {
        activeBallTransforms.Remove(ballTransform);
        if (activeBallTransforms.Count == 0) 
        {
            EventManager.onAllBallsThrown.Invoke(numberOfBalls);
        }
    }
}
