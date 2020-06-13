using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip step;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        //step = Resources.Load<AudioClip>("Audio/player_footsteps/player_footsteps_");
        audioSrc = GetComponent<AudioSource>();
    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "step":
                audioSrc.PlayOneShot(Resources.Load<AudioClip>("Audio/player_footsteps/player_footsteps_"+ Random.Range(1, 18)), 0.5f);
                break;
        }
    }
}
