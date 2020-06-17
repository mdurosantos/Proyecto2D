using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowController : MonoBehaviour
{
    public static GameFlowController Instance;
    private static bool paused = false;
    private static bool gameover = false;
    private static bool cursorInResume = true;
    private CanvasGroup resume;
    private CanvasGroup quit;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        resume = GameObject.FindGameObjectWithTag("Resume").GetComponent<CanvasGroup>();
        quit = GameObject.FindGameObjectWithTag("Quit").GetComponent<CanvasGroup>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!paused && PausedPressed() && !gameover)
        {
            paused = true;
            PauseGame();
        }
        else if (PauseUnpressed() && paused)
        {
            AudioManager.PlaySound("okUI");
            if (cursorInResume || Input.GetButtonDown("Cancel"))
            {      
                paused = false;
                UnPauseGame();
                NotGameOver();
            }
            else
            {
                SceneController.LoadScene("Start");
            }
        }
        else if (paused && Input.GetButtonDown("Vertical"))
        {
            MoveCursor();
            CheckCursor();
        }
        else if (PauseUnpressed() && gameover)
        {
            gameover = false;
            paused = false;
            UnPauseGame();
            NotGameOver();
        }
    }

    private void MoveCursor()
    {
        AudioManager.PlaySound("moveUI");
        cursorInResume = !cursorInResume;
    }

    private void CheckCursor()
    {
        if (cursorInResume)
        {
            resume.alpha = 1;
            quit.alpha = 0;
        }
        else
        {
            resume.alpha = 0;
            quit.alpha = 1;
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
        AudioManager.PlaySound("okUI");
        cursorInResume = true;
        CheckCursor();
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
        gameover = true;
        Time.timeScale = 0;
        InGameMenuController.Instance.SetGameOver();
        AudioManager.PlaySound("game_over");
    }

    public void NotGameOver()
    {
        gameover = false;
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
