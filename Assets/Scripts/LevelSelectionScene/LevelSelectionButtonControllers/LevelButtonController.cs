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

    Color lowerOpacity = new Color(255, 255, 255, 0.75f);                   // valge v2rv j2tab pildil originaalv2rvi, viimane v22rtus v2hendab l2bipaistvust
    Color lowerOpacityPurple = new Color(0.43f, 0.78f, 1, 0.75f);           // tumedam lilla v2rv koos v2iksema l2bipaistvusega
    Color imgOriginalColor = Color.white;                                   // valge v2rv t2hendab pildil originaalv2rvi

    public void ReduceOpacityAndDarken()                                    // funktsioon animatsiooni jaoks, v2hendab l2bipaistvust ja teeb nupu tumedamaks
    {
        levelButtonIMG.GetComponent<Image>().color = lowerOpacityPurple;    // funktsioon level nupu pildi v2rvi muutmiseks
        levelButtonAudio.GetComponent<AudioSource>();                       // SelectSoundi tuvastamine
        levelButtonAudio.Play();                                            // SelectSoundi m2ngimine
        Debug.Log("Level button clicked");
    }
    public void ChangeToOriginalColor()                                     // funktsioon animatsiooni jaoks
    {
        levelButtonIMG.GetComponent<Image>().color = imgOriginalColor;      // level nupu muutmine originaalv2rvile
    }
    public void ReduceOpacity()                                             // funktsioon animatsiooni jaoks
    {
        levelButtonIMG.GetComponent<Image>().color = lowerOpacity;          // level nupul l2bipaistvuse v2hendamine
    }
    public void ChangeScene(string sceneToLoad)                             // stseenivahetuse funktsioon
    {                                                                       // ylearuse BackButtonSFXi h2vitamine (ajutine lahendus duplikaat
        GameObject objectToDelete = GameObject.Find("BackButtonSFX");       // DontDestroyOnLoad objektide haldamiseks) 
        GameObject objectToDelete2 = GameObject.Find("BackgroundCanvas");   // menyy tausta tuvastamine
        Destroy(objectToDelete);
        SceneManager.LoadScene(sceneToLoad);                                // j2rgmise stseeni laadimise funktsioon
        if (sceneToLoad == "ImportScene" ||                                 // kui avatakse m6ni nendest stseenidest, h2vitatakse menyy taustapilt,
            sceneToLoad == "Level1Scene" ||                                 // sest levelis on erinev taust menyyst
            sceneToLoad == "Level2Scene" ||
            sceneToLoad == "Level3Scene")
        {
            Destroy(objectToDelete2);
        }
    }
}
