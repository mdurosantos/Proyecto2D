using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{

    public static void PlayAudio(AudioClip audio, Vector3 place, float volume, float pitch)
    {
        GameObject tempAP = new GameObject("audioSource");
        tempAP.transform.position = place;
        AudioSource tempAS = tempAP.AddComponent<AudioSource>();
        tempAS.clip = audio;
        tempAS.volume = volume;
        tempAS.pitch = pitch;
        //temp custom params
        tempAS.maxDistance = 50f;
        tempAS.dopplerLevel = 0f;
        tempAS.rolloffMode = AudioRolloffMode.Linear;
        tempAS.Play();
        Object.Destroy(tempAP, tempAS.clip.length);
    }
    public static void PlayAudio(AudioClip audio, Vector3 place, float volume) { PlayAudio(audio, place, volume, 1f); } //overload just volume
    public static void PlayAudio(AudioClip audio, Vector3 place) { PlayAudio(audio, place, 1f, 1f); } //overload basic

    public static void PlayRandomAudio(AudioClip[] audios, Vector3 place, float volume, bool randomPitch)
    {
        int roll = Random.Range(0, audios.Length);
        if (randomPitch) PlayAudio(audios[roll], place, volume, Random.Range(0.5f, 2f));
        else PlayAudio(audios[roll], place, volume);
    }
    public static void PlayRandomAudio(AudioClip[] audios, Vector3 place, float volume) { PlayRandomAudio(audios, place, volume, false); }
    public static void PlayRandomAudio(AudioClip[] audios, Vector3 place) { PlayRandomAudio(audios, place, 1f, false); }

}
