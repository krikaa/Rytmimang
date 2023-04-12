using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMenuMusic : MonoBehaviour
{
    void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "GameScene")
        {
            Destroy(gameObject);
        }
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
