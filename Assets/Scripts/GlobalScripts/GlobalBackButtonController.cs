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

    Color lowerOpacity = new Color(255, 255, 255, 0.75f);                   // valge v2rv j2tab pildil originaalv2rvi, viimane v22rtus v2hendab l2bipaistvust
    Color lowerOpacityPurple = new Color(0.43f, 0.78f, 1, 0.75f);           // tumedam lilla v2rv koos v2iksema l2bipaistvusega
    Color imgOriginalColor = Color.white;                                   // valge v2rv t2hendab pildil originaalv2rvi

    public void ReduceOpacityAndDarken()                                    // funktsioon animatsiooni jaoks, v2hendab l2bipaistvust ja teeb nupu tumedamaks
    {
        backButtonIMG.GetComponent<Image>().color = lowerOpacityPurple;     // funktsioon tagasinupu pildi v2rvi muutmiseks
        backButtonAudio.GetComponent<AudioSource>();                        // SelectSoundi tuvastamine
        backButtonAudio.Play();                                             // SelectSoundi m2ngimine
        Debug.Log("Back clicked");
    }
    public void ChangeToOriginalColor()                                     // funktsioon animatsiooni jaoks
    {
        backButtonIMG.GetComponent<Image>().color = imgOriginalColor;       // tagasinupu muutmine originaalv2rvile
    }

    public void ReduceOpacity()                                             // funktsioon animatsiooni jaoks
    {
        backButtonIMG.GetComponent<Image>().color = lowerOpacity;           // tagasinupul l2bipaistvuse v2hendamine
    }
    public void ChangeScene(string nextScene)                               // stseenivahetuse funktsioon
    {
        GameObject objectToDelete1 = GameObject.Find("PlayButtonSFX");      // ajutine lahendus kuidas kustutada duplikaat DontDestroyOnLoad objekte
        GameObject objectToDelete2 = GameObject.Find("OptionsButtonSFX");   // ehk minnes tagasi kuskilt stseenilt MenuScene'i, h2vitatakse hetkel DontDestroyOnLoad
        GameObject objectToDelete3 = GameObject.Find("LevelButtonSFX");     // all olnud menyy nuppude heliefektid (mida oli MenuScene'is vaja, et nupuvajutusel heliefekt ei katkeks)
        Destroy(objectToDelete1);                                           // kuna uue stseeni avamine lisab samad objektid uuesti DontDestroyOnLoad alla, siis tuleb eelmised h2vitada
        Destroy(objectToDelete2);
        Destroy(objectToDelete3);
        SceneManager.LoadScene(nextScene);                                  // j2rgmise stseeni laadimise funktsioon
    }
}
