using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDetections : MonoBehaviour
{
    public bool arrowAligned;
    public KeyCode keyBind;
    public GameObject badEffect, goodEffect, perfectEffect, missEffect; 

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
                    case (> 0.20f):
                        GameManager.instance.BadHit();
                        Instantiate(badEffect, transform.position, badEffect.transform.rotation);
                        Debug.Log("Bad");
                        break;

                    case (> 0.10f):
                        GameManager.instance.GoodHit();
                        Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                        Debug.Log("Good");
                        break;

                    case (<= 0.10f):
                        GameManager.instance.PerfectHit();
                        Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
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
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);
                GameManager.instance.NoteMissed();
            }
        }
    }
}
