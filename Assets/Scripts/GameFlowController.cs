using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowController : MonoBehaviour
{
    public static GameFlowController Instance;

    private void Awake()
    {
        Instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        if (PausedPressed())
            PauseGame();
        else if (PauseUnpressed())
        {
            UnPauseGame();
        }
    }

    private static bool PauseUnpressed()
    {
        return Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape);
    }

    private bool PausedPressed()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        InGameMenuController.Instance.SetPaused();
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        InGameMenuController.Instance.SetUnPaused();
    }

    

    /*public void RepeatLevel()
    {
        RestartGame();
        Time.timeScale = 1;
        InGameMenuController.Instance.SetUnPaused();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }*/
}
