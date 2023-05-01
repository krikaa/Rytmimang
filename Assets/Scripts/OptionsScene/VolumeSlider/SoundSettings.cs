using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour                                      // NB! KOOD ON @AIAdev POOLT YouTube'st
{
    [SerializeField] Slider soundSlider;
    [SerializeField] AudioMixer masterMixer;
    // Start is called before the first frame update
    void Start() 
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));              // m22ra slaideril volyymi v22rtuseks salvestatud helivaljudus
    }

    public void SetVolumeFromSlider()                                           // see funktsioon on attachitud slaideri objekti kylge
    {                                   
        SetVolume(soundSlider.value);                                           // mixeri volyymi muutmine vastavalt slaideri v22rtusele
    }

    public void SetVolume(float _value)                                         // funktsioon helivaljuduse m22ramiseks
    {
        if(_value < 1)                                                          // kui slaideri v22rtus on alla 1, siis m22ratakse volyymi v22rtus madalaks,
        {                                                                       // et MasterVolume't arvutades tuleks helivaljudus -100 dB,
            _value = 0.001f;                                                    // _value ei tohi panna 0, sest siis on logaritmitav 0
        }                                                                       
                                                                               
        RefreshSlider(_value);
        PlayerPrefs.SetFloat("SavedMasterVolume", _value);                      // salvesta volyymi v22rtus
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(_value / 100) * 20f);  // volyymi v22rtuse convertimine detsibellidesse ja MasterMixerile v22rtuse saatmine
    }                                                                           // slaideri v22rtused on 0 - 100, MasterVolume on -80 dB kuni 20 dB,
                                                                                // ehk kui slaider on max ehk 100, siis arvutades tulebki helivaljudus 20 dB
    public void RefreshSlider(float _value)                                     // slaideri v2rskendamine, et slaider muutuks vastavalt _value'le
    {
        soundSlider.value = _value;
    }
}
