using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private SensitivityController _sensitivityController;
    [SerializeField] private TextMeshProUGUI _sensitivityValueText;
    [SerializeField] private int _minSensitivity = 1;
    [SerializeField] private int _maxSensitivity = 11;
    [SerializeField] private Button decrementButton;
    [SerializeField] private Button incrementButton;

    private void Start()
    {
        UpdatePanel();
    }

    public void IncreaseSensitivity()
    {
        _sensitivityController.rotationSensitivity++;
        UpdatePanel();
    }

    public void DecreaseSensitivity() 
    {
        _sensitivityController.rotationSensitivity--;
        UpdatePanel();
    }

    private void UpdatePanel()
    {
        _sensitivityValueText.SetText(_sensitivityController.rotationSensitivity.ToString());
        if (_sensitivityController.rotationSensitivity <= _minSensitivity) decrementButton.interactable = false;
        else decrementButton.interactable = true;
        if (_sensitivityController.rotationSensitivity >= _maxSensitivity) incrementButton.interactable = false;
        else incrementButton.interactable = true;
    }
}
