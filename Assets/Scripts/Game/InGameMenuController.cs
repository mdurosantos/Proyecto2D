using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuController : MonoBehaviour
{
    public MenuPanel MenuPause;
    public static InGameMenuController Instance;
    private SpriteRenderer gameOverScreen;


    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        SetUnPaused();
        gameOverScreen = GameObject.FindGameObjectWithTag("GameOverScreen").GetComponent<SpriteRenderer>();
    }

    public void SetPaused()
    {
        MenuPause.Show();
    }

    public void SetUnPaused()
    {
        MenuPause.Hide();
    }

    public void SetGameOver()
    {
        gameOverScreen.enabled = true;
    }

    public void SetNotGameOver()
    {
        gameOverScreen.enabled = false;
    }

    public void OnUnPauseClicked()
    {
        GameFlowController.Instance.UnPauseGame();
    }

    /*public void TryAgain()
    {
        GameFlowController.Instance.RepeatLevel();
    }*/
}
