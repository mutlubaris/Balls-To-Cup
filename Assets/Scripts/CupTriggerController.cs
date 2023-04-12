using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CupTriggerController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private float loadNextSceneDelay = 1;
    
    private List<Transform> collectedBallTransforms = new List<Transform>();
    private int collectedBallQuantity;

    private void OnEnable()
    {
        EventManager.OnAllBallsThrown.AddListener(HandleLevelFinish);
    }

    private void OnDisable()
    {
        EventManager.OnAllBallsThrown.RemoveListener(HandleLevelFinish);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Ball" && !collectedBallTransforms.Contains(other.transform)) 
        { 
            collectedBallTransforms.Add(other.transform);
            other.GetComponentInParent<BallManager>().UpdateBallStatus(other.transform);
            collectedBallQuantity++;
            quantityText.SetText(collectedBallQuantity.ToString() + " / 20");
        }
    }

    private void HandleLevelFinish(int numberOfBalls)
    {
        StartCoroutine(LoadNextSceneCo(numberOfBalls));
    }

    private IEnumerator LoadNextSceneCo(int numberOfBalls)
    {
        yield return new WaitForSeconds(loadNextSceneDelay);
        if (numberOfBalls == collectedBallTransforms.Count)
        {
            if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings) SceneManager.LoadScene(0);
            else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
