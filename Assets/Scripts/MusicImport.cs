using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MusicImport : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public string musicName = "Highscore.mp3";

    // Start is called before the first frame update
    void Start()
    {
        string musicPath = "file://" + Application.streamingAssetsPath + "/Import/" + musicName;
        audioSource = gameObject.GetComponent<AudioSource>();
        StartCoroutine(GetAudioClip(musicPath));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetAudioClip(string musicPath)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(musicPath, AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClip = DownloadHandlerAudioClip.GetContent(www);
                audioClip.name = "importedMusic";
                audioSource.clip = audioClip;
            }
        }
    }
}
