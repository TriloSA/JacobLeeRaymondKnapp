/*****************************************************************************
// File Name :         CountdownScript.cs
// Author :            Jacob Lee
// Creation Date :     May 1st, 2023
//
// The script acts as the countdown before the players are roaming and
interacting with the level at actively uses sound effect one shots via the
sound manager as well as the anti-cheat box, and changing UI text to give
players visual feedback as well.
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownScript : MonoBehaviour
{
    public TextMeshProUGUI coundownText;
    public GameObject antiCheatBox;
    public AudioSource music;
    public GameObject countdownTextPanel;

    public AudioClip countdownSound;
    public AudioClip goSound;

    /// <summary>
    /// This is the initial countdown which plays audio, changes the UI text,
    /// and disables the anti-cheat wall. Music starts playing after countdown.
    /// </summary>
    /// <returns></returns>
    public IEnumerator Countdown()
    {
        countdownTextPanel.gameObject.SetActive(true);
        //Time.timeScale = 0;
        coundownText.text = "3";
        AudioManager.inst.PlaySound(countdownSound);

        yield return new WaitForSecondsRealtime(1f);
        coundownText.text = "2";
        AudioManager.inst.PlaySound(countdownSound);

        yield return new WaitForSecondsRealtime(1f);
        coundownText.text = "1";
        AudioManager.inst.PlaySound(countdownSound);

        yield return new WaitForSecondsRealtime(1f);
        coundownText.text = "GO!";
        AudioManager.inst.PlaySound(goSound);

        // Players can move again and anti-cheat box is removed;
        //Time.timeScale = 1;

        music.gameObject.SetActive(true);
        antiCheatBox.SetActive(false);

        yield return new WaitForSecondsRealtime(1f);
        coundownText.gameObject.SetActive(false);
        countdownTextPanel.gameObject.SetActive(false);

        
    }
}
