using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControls : MonoBehaviour
{

    private SpriteRenderer SR;
    private Color defaultColor = Color.white;
    private Color pressedColor = new Color(0.8862f, 0.2549f, 1, 1);

    public List<KeyCode> keyBind;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        SR.color = defaultColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetAnyKeyDown(keyBind))                 // muudab noole v2rvi nooleklahvi vajutades
        {
            SR.color = pressedColor;
        }

        if (GetAnyKeyUp(keyBind))                   // hoiab default noole v2rvi, kui nooleklahvi ei vajutata
        {
            SR.color = defaultColor;
        }
    }

    public static bool GetAnyKeyDown(List<KeyCode> aCodes)
    {
        for (int i = 0; i < aCodes.Count; i++)
            if (Input.GetKeyDown(aCodes[i]))
                return true;
        return false;
    }

    public static bool GetAnyKeyUp(List<KeyCode> aCodes)
    {
        for (int i = 0; i < aCodes.Count; i++)
            if (Input.GetKeyUp(aCodes[i]))
                return true;
        return false;
    }
}

