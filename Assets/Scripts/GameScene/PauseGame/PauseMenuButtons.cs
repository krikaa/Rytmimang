using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuButtons : MonoBehaviour
{
    public string sceneToLoad;
    public Image ButtonIMG;
    public AudioSource ButtonAudio;
    public GameObject pauseUI;
    public AudioSource gameAudio;

    Color lowerOpacity = new Color(255, 255, 255, 0.75f);                   // valge v2rv j2tab pildil originaalv2rvi, viimane v22rtus v2hendab l2bipaistvust
    Color lowerOpacityPurple = new Color(0.43f, 0.78f, 1, 0.75f);           // tumedam lilla v2rv koos v2iksema l2bipaistvusega
    Color imgOriginalColor = Color.white;                                   // valge v2rv t2hendab pildil originaalv2rvi

    public void ReduceOpacityAndDarken()                                    // funktsioon animatsiooni jaoks, v2hendab l2bipaistvust ja teeb nupu tumedamaks
    {
        ButtonIMG.GetComponent<Image>().color = lowerOpacityPurple;         // funktsioon tagasinupu pildi v2rvi muutmiseks
        ButtonAudio.GetComponent<AudioSource>();                            // SelectSoundi tuvastamine
        ButtonAudio.Play();                                                 // SelectSoundi m2ngimine
        Debug.Log("Level 1 clicked");
    }
    public void ChangeToOriginalColor()                                     // funktsioon animatsiooni jaoks
    {
        ButtonIMG.GetComponent<Image>().color = imgOriginalColor;           // tagasinupu muutmine originaalv2rvile
    }
    public void ReduceOpacity()                                             // funktsioon animatsiooni jaoks
    {
        ButtonIMG.GetComponent<Image>().color = lowerOpacity;               // tagasinupul l2bipaistvuse v2hendamine
    }
    public void ChangeScene(string sceneToLoad)                             // stseenivahetuse funktsioon
    {
        GameObject objectToDelete = GameObject.Find("BackButtonSFX");       // ajutine lahendus kuidas kustutada duplikaat DontDestroyOnLoad objekte
        GameObject objectToDelete2 = GameObject.Find("LevelSelectionSFX");  // ehk minnes tagasi kuskilt stseenilt MenuScene'i, h2vitatakse hetkel DontDestroyOnLoad
        Destroy(objectToDelete);                                            // all olnud menyy nuppude heliefektid (mida oli MenuScene'is vaja, et nupuvajutusel heliefekt ei katkeks)
        Destroy(objectToDelete2);                                           // kuna uue stseeni avamine lisab samad objektid uuesti DontDestroyOnLoad alla, siis tuleb eelmised h2vitada
        Time.timeScale = 1;                                                 // katkestab pausi
        SceneManager.LoadScene(sceneToLoad);                                // j2rgmise stseeni laadimise funktsioon
    }
    public void ResumeGame()                                                // funktisoon m2ngu j2tkamiseks
    {
        Time.timeScale = 1;                                                 // katkestab m2ngu pausi
        gameAudio.Play();                                                   // paneb muusika taas m2ngima
        pauseUI.SetActive(false);                                           // peidab 2ra pausimenyy
    }
}
