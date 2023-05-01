using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DontDestroySelectSound : MonoBehaviour
{
    private static DontDestroySelectSound instance;
    void Awake()                            // 2ra h2vita objekti stseeni vahetusel
    {                                       // kogu see skript on m6eldud yksikule objektile peale panemiseks
        DontDestroyOnLoad(gameObject);      // kuna siin aga pole yhtegi Destroy() k2sku, siis iga stseeni vahetusega
    }                                       // tekib DontDestroyOnLoad all mitmeid samu objekte
}                                      