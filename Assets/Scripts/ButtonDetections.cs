using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDetections : MonoBehaviour
{
    public bool arrowAligned;
    public KeyCode keyBind;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyBind))
        {
            if(arrowAligned)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            arrowAligned = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            arrowAligned = false;
        }
    }
}
