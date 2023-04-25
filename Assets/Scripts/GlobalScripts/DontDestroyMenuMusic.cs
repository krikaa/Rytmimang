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
        float volume = PlayerPrefs.GetFloat("SavedMasterVolume");
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(volume / 100) * 20f);
    }

    void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("MenuMusic");

        if (obj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
