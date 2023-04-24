using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuButtons : MonoBehaviour
{
    public string sceneToLoad;
    public Image ButtonIMG;
    public AudioSource ButtonAudio;
    public GameObject pauseUI;
    public AudioSource gameAudio;

    Color lowerOpacity = new Color(255, 255, 255, 0.75f);
    Color lowerOpacityPurple = new Color(0.43f, 0.78f, 1, 0.75f);
    Color imgOriginalColor = Color.white;

    public void ReduceOpacityAndDarken()
    {
        ButtonIMG.GetComponent<Image>().color = lowerOpacityPurple;
        ButtonAudio.GetComponent<AudioSource>();
        ButtonAudio.Play();
        Debug.Log("Level 1 clicked");
    }
    public void ChangeToOriginalColor()
    {
        ButtonIMG.GetComponent<Image>().color = imgOriginalColor;
    }
    public void ReduceOpacity()
    {
        ButtonIMG.GetComponent<Image>().color = lowerOpacity;
    }
    public void ChangeScene()
    {
        GameObject objectToDelete = GameObject.Find("BackButtonSFX");
        Destroy(objectToDelete);
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneToLoad);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameAudio.Play();
        pauseUI.SetActive(false);
    }
}
