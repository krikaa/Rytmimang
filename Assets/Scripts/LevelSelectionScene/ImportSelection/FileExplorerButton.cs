using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FileExplorerButton : MonoBehaviour
{
    public Image ExplorerButtonIMG;
    public AudioSource ButtonAudio;

    Color lowerOpacity = new Color(255, 255, 255, 0.75f);                   // valge v2rv j2tab pildil originaalv2rvi, viimane v22rtus v2hendab l2bipaistvust
    Color lowerOpacityPurple = new Color(0.43f, 0.78f, 1, 0.75f);           // tumedam lilla v2rv koos v2iksema l2bipaistvusega
    Color imgOriginalColor = Color.white;                                   // valge v2rv t2hendab pildil originaalv2rvi

    public void ReduceOpacityAndDarken()                                    // funktsioon animatsiooni jaoks, v2hendab l2bipaistvust ja teeb nupu tumedamaks
    {
        ExplorerButtonIMG.GetComponent<Image>().color = lowerOpacityPurple; // funktsioon tagasinupu pildi v2rvi muutmiseks
        ButtonAudio.GetComponent<AudioSource>();                            // SelectSoundi tuvastamine
        ButtonAudio.Play();                                                 // SelectSoundi m2ngimine
        Debug.Log("Level 1 clicked");
    }
    public void ChangeToOriginalColor()                                     // funktsioon animatsiooni jaoks
    {
        ExplorerButtonIMG.GetComponent<Image>().color = imgOriginalColor;   // tagasinupu muutmine originaalv2rvile
    }
    public void ReduceOpacity()                                             // funktsioon animatsiooni jaoks
    {
        ExplorerButtonIMG.GetComponent<Image>().color = lowerOpacity;       // tagasinupul l2bipaistvuse v2hendamine
    }
    public void OpenExplorer()                                              // funktsioon failihalduri avamiseks
    {
        Application.OpenURL("file://" + Application.streamingAssetsPath + "/Import/");  // avab failihalduri Import kaustas m2ngu asukoha j2rgi
    }
}