/*****************************************************************************
// File Name :         AudioManager.cs
// Author :            Jacob Lee
// Creation Date :     April 30th, 2023
//
// The script that allow other scripts to play a one shot audio sound to the
player(s) using the AudioManager game object.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager inst;
    public AudioSource aud;

    /// <summary>
    /// Makes it so other scripts can use this script and audio system.
    /// </summary>
    private void Awake()
    {
        inst = this;
    }

    /// <summary>
    /// Play a sound.
    /// </summary>
    /// <param name="sound"></param>
    public void PlaySound(AudioClip sound)
    {
        aud.PlayOneShot(sound);
    }

    /// <summary>
    /// If I wanted to, I could control the volume. This code currently does
    /// nothing.
    /// </summary>
    /// <param name="sound"></param>
    /// <param name="volume"></param>
    /*public void PlaySound(AudioClip sound, float volume)
    {
        aud.PlayOneShot(sound, volume);
    }*/

    /// <summary>
    /// If we were to make an options menu, make the slider's value change to
    /// the game's slider through here. This currently does nothing.
    /// </summary>
    /// <param name="vol"></param>
    /*public void ChangeVolume(float vol)
    {
        aud.volume = vol;
    }*/
}
