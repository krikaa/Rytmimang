using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseToggle : MonoBehaviour
{
    public KeyCode keyBind;
    public AudioSource gameAudio;
    public GameObject pauseUI;
    public GameObject scoreboard;

    void Update()
    {
        if (Input.GetKeyDown(keyBind) && !scoreboard.activeInHierarchy)
        {
            if (Time.timeScale == 1)
            {
                gameAudio.Pause();
                Time.timeScale = 0;
                pauseUI.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                gameAudio.Play();
                pauseUI.SetActive(false);
            }
        }
    }
}
