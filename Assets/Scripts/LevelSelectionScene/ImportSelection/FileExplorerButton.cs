using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FileExplorerButton : MonoBehaviour
{
    public Image ExplorerButtonIMG;
    public AudioSource ButtonAudio;

    Color lowerOpacity = new Color(255, 255, 255, 0.75f);
    Color lowerOpacityPurple = new Color(0.43f, 0.78f, 1, 0.75f);
    Color imgOriginalColor = Color.white;

    public void ReduceOpacityAndDarken()
    {
        ExplorerButtonIMG.GetComponent<Image>().color = lowerOpacityPurple;
        ButtonAudio.GetComponent<AudioSource>();
        ButtonAudio.Play();
        Debug.Log("Level 1 clicked");
    }
    public void ChangeToOriginalColor()
    {
        ExplorerButtonIMG.GetComponent<Image>().color = imgOriginalColor;
    }
    public void ReduceOpacity()
    {
        ExplorerButtonIMG.GetComponent<Image>().color = lowerOpacity;
    }
    public void OpenExplorer()
    {
        Application.OpenURL("file://" + Application.streamingAssetsPath + "/Import/");
    }
}