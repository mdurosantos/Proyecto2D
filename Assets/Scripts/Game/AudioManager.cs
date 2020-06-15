using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip[] step;
    public static AudioClip key;
    public static AudioClip open_door;
    public static AudioClip player_detected;
    static AudioSource audioSrc;

    void Start()
    {
        step = new AudioClip[17];
        for (int i = 0; i < 17; i++)
        {
            step[i] = Resources.Load<AudioClip>("Audio/player_footsteps/player_footsteps_" + (i + 1));
        }
        key = Resources.Load<AudioClip>("Audio/key");
        open_door = Resources.Load<AudioClip>("Audio/open_door");
        player_detected = Resources.Load<AudioClip>("Audio/player_detected");
        audioSrc = GetComponent<AudioSource>();
    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "step":
                audioSrc.PlayOneShot(step[Random.Range(0, 17)], 0.5f);
                break;
            case "key":
                audioSrc.PlayOneShot(key, 0.2f);
                break;
            case "open_door":
                audioSrc.PlayOneShot(open_door, 0.3f);
                break;
            case "player_detected":
                audioSrc.PlayOneShot(player_detected, 0.8f);
                break;
        }
    }
}
