using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MusicImport : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public string musicName;

    // Start is called before the first frame update
    void Start()
    {
        string musicPath = "file://" + Application.streamingAssetsPath + "/Import/" + musicName;    // string, mis hoiab m2ngu kaustades streamingAssets/Import/ asuva muusikafaili asukohta ja nime
        audioSource = gameObject.GetComponent<AudioSource>();                                       // v6tab preaguse objekti komponendi andmed
        StartCoroutine(GetAudioClip(musicPath));                                                    // alustab GetAudioClip coroutine-i v6ttes kaasa faili asukoha andmed (coroutine jooksutab funktsiooni mitme kaadri jooksul), vajalik IEnumeratori jaoks
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetAudioClip(string musicPath)                                                                       // IEnumerator - return tyybiga "funktsioon", mis j2tab eelmise returni meelde
    {
        using (UnityWebRequest musicRequest = UnityWebRequestMultimedia.GetAudioClip(musicPath, AudioType.MPEG))     // muutuja, millele m22ratakse funktsioon, millega Unity yritab hankida kindlast kaustast mp2/mp3 tyypi faili
        {
            yield return musicRequest.SendWebRequest();                                                              // saadab failip2ringu, j2tkab muuga kuni tuleb yks allolevatest vastustest

            if (musicRequest.result == UnityWebRequest.Result.ConnectionError)                                       // kui p2ring eba6nnestus,
            {
                Debug.Log(musicRequest.error);                                                                       
            }
            else                                                                                            // kui p2ring 6nnestus,
            {
                audioClip = DownloadHandlerAudioClip.GetContent(musicRequest);                              // salvestab saadud helifaili heliklipina
                audioClip.name = "importedMusic";                                                           // paneb heliklipile nime
                audioSource.clip = audioClip;                                                               // m22rab saadud heliklipi praeguse objekti audioallika heliklipiks
            }
        }
    }
}

