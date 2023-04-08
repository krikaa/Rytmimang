using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButtonController : MonoBehaviour
{
    public Image exitButtonIMG;
    public AudioSource exitButtonAudio;

    Color lowerOpacity = new Color(255, 255, 255, 0.75f);
    Color lowerOpacityPurple = new Color(0.43f, 0.78f, 1, 0.75f);
    Color imgOriginalColor = Color.white;

    public void ReduceOpacityAndDarken()
    {
        exitButtonIMG.GetComponent<Image>().color = lowerOpacityPurple;
        exitButtonAudio.GetComponent<AudioSource>();
        exitButtonAudio.Play();
        Debug.Log("Exit clicked");
    }
    public void ChangeToOriginalColor()
    {
        exitButtonIMG.GetComponent<Image>().color = imgOriginalColor;
    }
    public void ReduceOpacity()
    {
        exitButtonIMG.GetComponent<Image>().color = lowerOpacity;
    }
}
