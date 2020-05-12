using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuController : MonoBehaviour
{
    public MenuPanel MenuPause;
    public static InGameMenuController Instance;


    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        SetUnPaused();
    }

    public void SetPaused()
    {
        MenuPause.Show();
    }

    public void SetUnPaused()
    {
        MenuPause.Hide();
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
