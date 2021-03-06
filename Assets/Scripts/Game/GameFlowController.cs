﻿using System;
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
    private Animator gameOverScreenAnimator;
    private GameObject[] resetEnemiesPosition;
    private EnemyPatrol enemyPatrol;
    private PlayerPos resetPlayerPosition;
    private PlayerMovement movement;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        resume = GameObject.FindGameObjectWithTag("Resume").GetComponent<CanvasGroup>();
        quit = GameObject.FindGameObjectWithTag("Quit").GetComponent<CanvasGroup>();
        resetEnemiesPosition = GameObject.FindGameObjectsWithTag("Enemy");
        gameOverScreenAnimator = GameObject.FindGameObjectWithTag("GameOverScreen").GetComponent<Animator>();
        resetPlayerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPos>();
        movement= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
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
                Time.timeScale = 1;
                paused = false;
                UnPauseGame();
                NotGameOver();
                SceneController.LoadScene("Start");
            }
        }
        else if (paused && Input.GetButtonDown("Vertical"))
        {
            MoveCursor();
            CheckCursor();
        }
        else if (PauseUnpressed() && gameover && PlayGameOver.getFinished())
        {
            gameover = false;
            PlayGameOver.setFinished(false);
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
        gameOverScreenAnimator.SetBool("gameOver", gameover);
        //Time.timeScale = 0;
        movement.setCanMove(false);
        Invoke("ResetPlayer", 0.3f);
        Invoke("ResetEnemies", 0.4f);
        InGameMenuController.Instance.SetGameOver();
        
    }

    public void NotGameOver()
    {
        gameover = false;
        gameOverScreenAnimator.SetBool("gameOver", gameover);
        //Time.timeScale = 1;
        InGameMenuController.Instance.SetNotGameOver();
        
        
        movement.setCanMove(true);
    }
    public bool GetGameOver()
    {
        return gameover;
    }
    void ResetPlayer()
    {
        resetPlayerPosition.GoToCheckPoint();
    }
    void ResetEnemies()
    {
        foreach (GameObject enemy in resetEnemiesPosition)
        {
            enemyPatrol = enemy.GetComponent<EnemyPatrol>();
            enemyPatrol.SetPlayerDetected(false);
            enemyPatrol.ResetPosition();
        }
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
