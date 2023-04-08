using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonController : MonoBehaviour
{
    public Image playButtonIMG;

    Color lowerOpacity = new Color(255, 255, 255, 0.75f);
    Color lowerOpacityPurple = new Color(0.43f, 0.78f, 1, 0.75f);
    Color imgOriginalColor = Color.white;

    public void ReduceOpacityAndDarken()
    {
        playButtonIMG.GetComponent<Image> ().color = lowerOpacityPurple;
        Debug.Log("Play clicked");
    }
    public void ChangeToOriginalColor()
    {
        playButtonIMG.GetComponent <Image> ().color = imgOriginalColor;
    }
    public void ReduceOpacity()
    {
        playButtonIMG.GetComponent <Image>().color = lowerOpacity;
    }
}
