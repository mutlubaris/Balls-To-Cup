using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CupTriggerController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _quantityText;
    [SerializeField] private float _loadNextSceneDelay = 1;
    
    private List<Transform> _collectedBallTransforms = new List<Transform>();
    private int _ollectedBallQuantity;

    private void OnEnable()
    {
        EventManager.onAllBallsThrown.AddListener(HandleLevelFinish);
    }

    private void OnDisable()
    {
        EventManager.onAllBallsThrown.RemoveListener(HandleLevelFinish);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Ball" && !_collectedBallTransforms.Contains(other.transform)) 
        { 
            _collectedBallTransforms.Add(other.transform);
            other.GetComponentInParent<BallManager>().UpdateBallStatus(other.transform);
            _ollectedBallQuantity++;
            _quantityText.SetText(_ollectedBallQuantity.ToString() + " / 20");
        }
    }

    private void HandleLevelFinish(int numberOfBalls)
    {
        StartCoroutine(LoadNextSceneCo(numberOfBalls));
    }

    private IEnumerator LoadNextSceneCo(int numberOfBalls)
    {
        yield return new WaitForSeconds(_loadNextSceneDelay);
        if (numberOfBalls == _collectedBallTransforms.Count)
        {
            LevelManager.LoadNextLevel();
        }
        else LevelManager.ReloadLevel();
    }
}
