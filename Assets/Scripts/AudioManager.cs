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
<<<<<<< HEAD
                audioSrc.PlayOneShot(Resources.Load<AudioClip>("Audio/player_footsteps/player_footsteps_"+ Random.Range(1, 18)), 0.5f);
=======
                audioSrc.PlayOneShot(step[Random.Range(0, 17)], 0.5f);
>>>>>>> 2f140aa9cb843014ed7937726695890464209885
                break;
        }
    }
}
