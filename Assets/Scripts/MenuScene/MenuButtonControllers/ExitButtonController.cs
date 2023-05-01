using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButtonController : MonoBehaviour
{
    public Image exitButtonIMG;
    public AudioSource exitButtonAudio;

    Color lowerOpacity = new Color(255, 255, 255, 0.75f);               // valge v2rv j2tab pildil originaalv2rvi, viimane v22rtus v2hendab l2bipaistvust
    Color lowerOpacityPurple = new Color(0.43f, 0.78f, 1, 0.75f);       // tumedam lilla v2rv koos v2iksema l2bipaistvusega
    Color imgOriginalColor = Color.white;                               // valge v2rv t2hendab pildil originaalv2rvi

    public void ReduceOpacityAndDarken()                                // funktsioon animatsiooni jaoks, v2hendab l2bipaistvust ja teeb nupu tumedamaks
    {
        exitButtonIMG.GetComponent<Image>().color = lowerOpacityPurple; // funktsioon exit nupu pildi v2rvi muutmiseks
        exitButtonAudio.GetComponent<AudioSource>();                    // SelectSoundi tuvastamine
        exitButtonAudio.Play();                                         // SelectSoundi m2ngimine
        Debug.Log("Exit clicked");
    }
    public void ChangeToOriginalColor()                                 // funktsioon animatsiooni jaoks
    {
        exitButtonIMG.GetComponent<Image>().color = imgOriginalColor;   // exit nupu muutmine originaalv2rvile
    }
    public void ReduceOpacity()                                         // funktsioon animatsiooni jaoks
    {
        exitButtonIMG.GetComponent<Image>().color = lowerOpacity;       // exit nupul l2bipaistvuse v2hendamine
    }
    public void QuitGame()                                              // funktsioon m2ngu sulgemiseks
    {
        Application.Quit();                                             // sulgeb avatud exe faili
    }
}
