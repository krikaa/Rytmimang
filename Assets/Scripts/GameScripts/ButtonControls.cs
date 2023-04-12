using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControls : MonoBehaviour
{

    private SpriteRenderer SR;
    private Color defaultColor = Color.white;
    private Color pressedColor = new Color(0.8862f, 0.2549f, 1, 1);

    public KeyCode keyBind;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        SR.color = defaultColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyBind))                 // muudab noole v2rvi nooleklahvi vajutades
        {
            SR.color = pressedColor;
        }

        if (Input.GetKeyUp(keyBind))                   // hoiab default noole v2rvi, kui nooleklahvi ei vajutata
        {
            SR.color = defaultColor;
        }
    }
}

