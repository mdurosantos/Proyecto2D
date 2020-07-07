using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public static StartController Instance;
    private static bool cursorInResume = true;
    private CanvasGroup resume;
    private CanvasGroup quit;
    private LevelChanger levelChanger;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        resume = GameObject.FindGameObjectWithTag("Resume").GetComponent<CanvasGroup>();
        quit = GameObject.FindGameObjectWithTag("Quit").GetComponent<CanvasGroup>();
        levelChanger = GameObject.FindGameObjectWithTag("LevelChanger").GetComponent<LevelChanger>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            AudioManager.PlaySound("okUI");
            if (cursorInResume)
            {
                levelChanger.FadeToLevel("next");
                //SceneController.LoadNextScene();
            }
            else
            {
                Debug.Log("Quit");
                Application.Quit();

            }
        }
        else if (Input.GetButtonDown("Vertical"))
        {
            MoveCursor();
            CheckCursor();
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
}



    

