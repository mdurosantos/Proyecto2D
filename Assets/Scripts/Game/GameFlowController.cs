using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowController : MonoBehaviour
{
    public static GameFlowController Instance;
    private static bool paused = false;

    private void Awake()
    {
        Instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        if (!paused && PausedPressed())
        {
            paused = true;
            PauseGame();
        }
        else if (PauseUnpressed())
        {
            paused = false;
            UnPauseGame();
            NotGameOver();
        }
    }

    private static bool PauseUnpressed()
    {
        return Input.GetButtonDown("Interact") || Input.GetButtonDown("Cancel");
    }

    private bool PausedPressed()
    {
        return Input.GetButtonDown("Cancel");
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

    public void GameOver()
    {
        Time.timeScale = 0;
        InGameMenuController.Instance.SetGameOver();
        AudioManager.PlaySound("game_over");
    }

    public void NotGameOver()
    {
        Time.timeScale = 1;
        InGameMenuController.Instance.SetNotGameOver();
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
