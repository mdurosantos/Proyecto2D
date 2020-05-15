using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    public static void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public static void LoadNextScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public static void LoadPreviousScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    /*public void QuitGame()
    {
        Application.Quit();
    }*/



}
