using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControls : MonoBehaviour
{

    private SpriteRenderer SR;
    private Color defaultColor = Color.white;
    private Color pressedColor = new Color(0.75f, 0f, 0.5f, 1f);

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

