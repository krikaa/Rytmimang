using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMenuBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("MenuBackground");

        if (obj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
