using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private SensitivityController _sensitivityController;
    [SerializeField] private TextMeshProUGUI _sensitivityValueText;

    private void Start()
    {
        _sensitivityValueText.SetText(_sensitivityController.rotationSensitivity.ToString());
    }

    public void IncreaseSensitivity()
    {
        _sensitivityController.rotationSensitivity++;
        _sensitivityValueText.SetText(_sensitivityController.rotationSensitivity.ToString());
    }

    public void DecreaseSensitivity() 
    {
        _sensitivityController.rotationSensitivity--;
        _sensitivityValueText.SetText(_sensitivityController.rotationSensitivity.ToString());
    }
}
