using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class DontDestroyMenuMusic : MonoBehaviour
{
    [SerializeField] AudioMixer masterMixer;
    void Start()
    {
        float volume = PlayerPrefs.GetFloat("SavedMasterVolume");               // volyymi v22rtus MasterVolume mikseril SoundSettings skriptist
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(volume / 100) * 20f);  // volume slideri helivaljuduse arvutamine
    }

    void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("MenuMusic");      // leia objektid, millel on kyljes silt "MenuMusic"

        if (obj.Length > 1)                                                     // kui selliseid objekte eksiteerib rohkem kui yks, h2vita yks neist
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);                                     // muul juhul 2ra h2vita objekti stseeni vahetusel
    }
}
