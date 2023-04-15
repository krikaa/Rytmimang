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
        if(Input.GetKeyDown(keyBind))                                                                    // kui nooleklahvi vajutatakse
        {
            if(arrowAligned)                                                                             // kui noot on samal positsioonil noolega
            {
                gameObject.SetActive(false);                                                             // siis noot kustutatakse

                switch(Mathf.Abs(transform.position.y))                                                  // tuvastab 2ra kauguse noodi ja noole vahel
                {
                    case (> 0.20f):                                                                      // halvimal juhul BadHit
                        GameManager.instance.BadHit();                                                   // loeb sisse halva tabamuse
                        Instantiate(badEffect, transform.position, badEffect.transform.rotation);        // tekitab visuaalse tagasiside 6igesse kohta
                        Debug.Log("Bad");
                        break;

                    case (> 0.10f):                                                                      // natuke paremal juhul GoodHit
                        GameManager.instance.GoodHit();                                                  // loeb sisse hea tabamuse
                        Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);      // tekitab visuaalse tagasiside 6igesse kohta
                        Debug.Log("Good");
                        break;

                    case (<= 0.10f):                                                                     // parimal juhul PerfectHit
                        GameManager.instance.PerfectHit();                                               // loeb sisse perfektse tabamuse
                        Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);// tekitab visuaalse tagasiside 6igesse kohta
                        Debug.Log("Perfect");
                        break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // kontrollib, kas noot on samal positsioonil noolega
    {
        if(other.tag == "Activator")
        {
            arrowAligned = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) // kontrollib, kas nooti ei tabatud
    {
        if(gameObject.activeSelf)
        {
            if (other.tag == "Activator")
            {
                arrowAligned = false;
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);              // tekitab visuaalse tagasiside 6igesse kohta
                GameManager.instance.NoteMissed();                                                       // loeb sisse tabamata noodi
            }
        }
    }
}
