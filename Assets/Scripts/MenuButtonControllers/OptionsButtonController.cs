using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsButtonController : MonoBehaviour
{
    public Image optionsButtonIMG;

    Color lowerOpacity = new Color(255, 255, 255, 0.75f);
    Color lowerOpacityPurple = new Color(0.43f, 0.78f, 1, 0.75f);
    Color imgOriginalColor = Color.white;

    public void ReduceOpacityAndDarken()
    {
        optionsButtonIMG.GetComponent<Image>().color = lowerOpacityPurple;
        Debug.Log("Options clicked");
    }
    public void ChangeToOriginalColor()
    {
        optionsButtonIMG.GetComponent<Image>().color = imgOriginalColor;
    }
    public void ReduceOpacity()
    {
        optionsButtonIMG.GetComponent<Image>().color = lowerOpacity;
    }
}
