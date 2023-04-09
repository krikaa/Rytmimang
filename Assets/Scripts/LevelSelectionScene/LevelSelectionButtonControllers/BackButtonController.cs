using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButtonController : MonoBehaviour
{
    public Image backButtonIMG;
    public AudioSource backButtonAudio;

    Color lowerOpacity = new Color(255, 255, 255, 0.75f);
    Color lowerOpacityPurple = new Color(0.43f, 0.78f, 1, 0.75f);
    Color imgOriginalColor = Color.white;

    public void ReduceOpacityAndDarken()
    {
        backButtonIMG.GetComponent<Image>().color = lowerOpacityPurple;
        backButtonAudio.GetComponent<AudioSource>();
        backButtonAudio.Play();
        Debug.Log("Level 1 clicked");
    }
    public void ChangeToOriginalColor()
    {
        backButtonIMG.GetComponent<Image>().color = imgOriginalColor;
    }
    public void ReduceOpacity()
    {
        backButtonIMG.GetComponent<Image>().color = lowerOpacity;
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
