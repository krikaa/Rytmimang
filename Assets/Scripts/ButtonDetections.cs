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

                switch(Mathf.Abs(transform.position.y))
                {
                    case (> 0.15f):
                        GameManager.instance.BadHit();
                        Debug.Log("Bad");
                        break;

                    case (> 0.05f):
                        GameManager.instance.GoodHit();
                        Debug.Log("Good");
                        break;

                    case (<= 0.05f):
                        GameManager.instance.PerfectHit();
                        Debug.Log("Perfect");
                        break;
                }
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
        if(gameObject.activeSelf)
        {
            if (other.tag == "Activator")
            {
                arrowAligned = false;

                GameManager.instance.NoteMissed();
            }
        }
    }
}
