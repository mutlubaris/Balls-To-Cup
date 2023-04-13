using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager 
{
    public static void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings) SceneManager.LoadScene(0);
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
