using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DontDestroySelectSound : MonoBehaviour
{
    private static DontDestroySelectSound instance;
    void Awake()
    {        
        DontDestroyOnLoad(gameObject);
    }
}