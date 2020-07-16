using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGameOver : MonoBehaviour
{
    private static bool finished;
    public void PlayGameOverSound()
    {
        AudioManager.PlaySound("game_over");
        finished = true;
    }

    public void PlayPreGameOverSound()
    {
        AudioManager.PlaySound("pre_game_over");
    }

    public static void setFinished(bool f)
    {
        finished = f;
    }

    public static bool getFinished()
    {
        return finished;
    }
}
