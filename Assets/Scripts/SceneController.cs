using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController
{
    public static void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public static void LoadNextScene()
    {
        SceneManager.LoadScene(GetCurrentSceneIndex() + 1);
    }

    public static void LoadPreviousScene()
    {
        SceneManager.LoadScene(GetCurrentSceneIndex() - 1);
    }

    private static int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public static void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    /*public void QuitGame()
    {
        Application.Quit();
    }*/



}
