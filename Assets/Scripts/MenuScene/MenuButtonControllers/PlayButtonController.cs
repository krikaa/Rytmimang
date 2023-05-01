using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButtonController : MonoBehaviour
{
    public Image playButtonIMG;
    public AudioSource playButtonAudio;

    Color lowerOpacity = new Color(255, 255, 255, 0.75f);                   // valge v2rv j2tab pildil originaalv2rvi, viimane v22rtus v2hendab l2bipaistvust
    Color lowerOpacityPurple = new Color(0.43f, 0.78f, 1, 0.75f);           // tumedam lilla v2rv koos v2iksema l2bipaistvusega
    Color imgOriginalColor = Color.white;                                   // valge v2rv t2hendab pildil originaalv2rvi

    public void ReduceOpacityAndDarken()                                    // funktsioon animatsiooni jaoks, v2hendab l2bipaistvust ja teeb nupu tumedamaks
    {
        playButtonIMG.GetComponent<Image> ().color = lowerOpacityPurple;    // funktsioon play nupu pildi v2rvi muutmiseks
        playButtonAudio.GetComponent<AudioSource> ();                       // SelectSoundi tuvastamine
        playButtonAudio.Play();                                             // SelectSoundi m2ngimine
        Debug.Log("Play clicked");
    }
    public void ChangeToOriginalColor()                                     // funktsioon animatsiooni jaoks
    {
        playButtonIMG.GetComponent <Image> ().color = imgOriginalColor;     // play nupu muutmine originaalv2rvile
    }
    public void ReduceOpacity()                                             // funktsioon animatsiooni jaoks
    {
        GameObject objectToDelete = GameObject.Find("BackButtonSFX");       // ylearuse BackButtonSFXi hävitamine (ajutine lahendus duplikaat
        Destroy(objectToDelete);                                            // DontDestroyOnLoad objektide haldamiseks)
        playButtonIMG.GetComponent <Image>().color = lowerOpacity;          // play nupul l2bipaistvuse v2hendamine
    }
    public void ChangeScene()                                               // stseenivahetuse funktsioon
    {
        GameObject objectToDelete = GameObject.Find("BackButtonSFX");       // ylearuse BackButtonSFXi h2vitamine (ajutine lahendus duplikaat
        Destroy(objectToDelete);                                            // DontDestroyOnLoad objektide haldamiseks)
        SceneManager.LoadScene("LevelSelectionScene");                      // j2rgmise stseeni laadimise funktsioon
    }
}
