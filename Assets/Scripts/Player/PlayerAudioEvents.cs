using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioEvents : MonoBehaviour
{
    void PlayStep()
    {
        AudioManager.PlaySound("step");
    }
}
