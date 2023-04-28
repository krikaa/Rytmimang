using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButtonController : MonoBehaviour
{
    public string sceneToLoad;
    public Image levelButtonIMG;
    public AudioSource levelButtonAudio;

    Color lowerOpacity = new Color(255, 255, 255, 0.75f);
    Color lowerOpacityPurple = new Color(0.43f, 0.78f, 1, 0.75f);
    Color imgOriginalColor = Color.white;

    public void ReduceOpacityAndDarken()
    {
        levelButtonIMG.GetComponent<Image>().color = lowerOpacityPurple;
        levelButtonAudio.GetComponent<AudioSource>();
        levelButtonAudio.Play();
        Debug.Log("Level 1 clicked");
    }
    public void ChangeToOriginalColor()
    {
        levelButtonIMG.GetComponent<Image>().color = imgOriginalColor;
    }
    public void ReduceOpacity()
    {
        levelButtonIMG.GetComponent<Image>().color = lowerOpacity;
    }
    public void ChangeScene(string sceneToLoad)
    {
        GameObject objectToDelete = GameObject.Find("BackButtonSFX");
        GameObject objectToDelete2 = GameObject.Find("BackgroundCanvas");
        Destroy(objectToDelete);
        SceneManager.LoadScene(sceneToLoad);
        if (sceneToLoad == "ImportScene" ||
            sceneToLoad == "Level1Scene" ||
            sceneToLoad == "Level2Scene" ||
            sceneToLoad == "Level3Scene")
        {
            Destroy(objectToDelete2);
        }
    }
}
