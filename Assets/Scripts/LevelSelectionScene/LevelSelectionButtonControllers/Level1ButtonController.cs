using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level1ButtonController : MonoBehaviour
{
    public Image level1ButtonIMG;
    public AudioSource level1ButtonAudio;

    Color lowerOpacity = new Color(255, 255, 255, 0.75f);
    Color lowerOpacityPurple = new Color(0.43f, 0.78f, 1, 0.75f);
    Color imgOriginalColor = Color.white;

    public void ReduceOpacityAndDarken()
    {
        level1ButtonIMG.GetComponent<Image>().color = lowerOpacityPurple;
        level1ButtonAudio.GetComponent<AudioSource>();
        level1ButtonAudio.Play();
        Debug.Log("Level 1 clicked");
    }
    public void ChangeToOriginalColor()
    {
        level1ButtonIMG.GetComponent<Image>().color = imgOriginalColor;
    }
    public void ReduceOpacity()
    {
        level1ButtonIMG.GetComponent<Image>().color = lowerOpacity;
    }
    public void ChangeScene()
    {
        GameObject objectToDelete = GameObject.Find("BackButtonSFX");
        Destroy(objectToDelete);
        SceneManager.LoadScene("GameScene");
    }
}
