using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControls : MonoBehaviour
{

    private SpriteRenderer SR;
    public Color defaultColor = Color.black;
    public Color pressedColor = Color.white;

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
        if (Input.GetKeyDown(keyBind))
        {
            SR.color = pressedColor;
        }

        if (Input.GetKeyUp(keyBind))
        {
            SR.color = defaultColor;
        }
    }
}

