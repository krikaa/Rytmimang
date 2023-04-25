using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalBackButtonController : MonoBehaviour
{
    public string nextScene;
    public Image backButtonIMG;
    public AudioSource backButtonAudio;
    public DontDestroySelectSound destroySound;

    Color lowerOpacity = new Color(255, 255, 255, 0.75f);
    Color lowerOpacityPurple = new Color(0.43f, 0.78f, 1, 0.75f);
    Color imgOriginalColor = Color.white;

    public void ReduceOpacityAndDarken()
    {
        backButtonIMG.GetComponent<Image>().color = lowerOpacityPurple;
        backButtonAudio.GetComponent<AudioSource>();
        backButtonAudio.Play();
        Debug.Log("Back clicked");
    }
    public void ChangeToOriginalColor()
    {
        backButtonIMG.GetComponent<Image>().color = imgOriginalColor;
    }

    public void ReduceOpacity()
    {
        backButtonIMG.GetComponent<Image>().color = lowerOpacity;
    }
    public void ChangeScene(string nextScene)
    {
        GameObject objectToDelete1 = GameObject.Find("PlayButtonSFX"); // ajutine lahendus kuidas kustutada duplikaat DontDestroyOnLoad objekte
        GameObject objectToDelete2 = GameObject.Find("OptionsButtonSFX");
        GameObject objectToDelete3 = GameObject.Find("LevelButtonSFX");
        Destroy(objectToDelete1);
        Destroy(objectToDelete2);
        Destroy(objectToDelete3);
        SceneManager.LoadScene(nextScene);
    }
}
