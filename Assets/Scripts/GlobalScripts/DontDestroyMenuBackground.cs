using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMenuBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("MenuBackground"); // leia objektid, mis on m2rgitud sildiga "MenuBackground"

        if (obj.Length > 1)                                                     // kui eksisteerib korraga rohkem kui yks objekt, siis h2vita yks neist
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);                                     // muul juhul j2ta objekt stseeni vahetusel alles
    }
}
