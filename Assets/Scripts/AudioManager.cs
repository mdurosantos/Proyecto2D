using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip [] step;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        step = new AudioClip[17];
        for (int i = 0; i<17; i++)
        {
            step[i]= Resources.Load<AudioClip>("Audio/player_footsteps/player_footsteps_"+(i+1));
        }
        audioSrc = GetComponent<AudioSource>();
    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "step":
                audioSrc.PlayOneShot(step[Random.Range(0, 17)], 0.5f);
                break;
        }
    }
}
