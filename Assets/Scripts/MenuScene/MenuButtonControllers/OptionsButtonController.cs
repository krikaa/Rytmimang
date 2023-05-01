using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsButtonController : MonoBehaviour
{
    public Image optionsButtonIMG;
    public AudioSource optionsButtonAudio;

    Color lowerOpacity = new Color(255, 255, 255, 0.75f);                   // valge v2rv j2tab pildil originaalv2rvi, viimane v22rtus v2hendab l2bipaistvust
    Color lowerOpacityPurple = new Color(0.43f, 0.78f, 1, 0.75f);           // tumedam lilla v2rv koos v2iksema l2bipaistvusega
    Color imgOriginalColor = Color.white;                                   // valge v2rv t2hendab pildil originaalv2rvi

    public void ReduceOpacityAndDarken()                                    // funktsioon animatsiooni jaoks, v2hendab l2bipaistvust ja teeb nupu tumedamaks
    {
        optionsButtonIMG.GetComponent<Image>().color = lowerOpacityPurple;  // funktsioon options nupu pildi v2rvi muutmiseks
        optionsButtonAudio.GetComponent<AudioSource>();                     // SelectSoundi tuvastamine
        optionsButtonAudio.Play();                                          // SelectSoundi m2ngimine
        Debug.Log("Options clicked");
    }
    public void ChangeToOriginalColor()                                     // funktsioon animatsiooni jaoks
    {
        optionsButtonIMG.GetComponent<Image>().color = imgOriginalColor;    // options nupu muutmine originaalv2rvile
    }
    public void ReduceOpacity()                                             // funktsioon animatsiooni jaoks
    {
        optionsButtonIMG.GetComponent<Image>().color = lowerOpacity;        // options nupul l2bipaistvuse v2hendamine
    }
    public void ChangeScene()                                               // stseenivahetuse funktsioon
    {
        GameObject objectToDelete = GameObject.Find("BackButtonSFX");       // ylearuse BackButtonSFXi h2vitamine(ajutine lahendus duplikaat
        Destroy(objectToDelete);                                            // DontDestroyOnLoad objektide haldamiseks)
        SceneManager.LoadScene("OptionsScene");                             // j2rgmise stseeni laadimise funktsioon
    }
}
