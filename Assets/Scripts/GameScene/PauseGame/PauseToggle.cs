using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseToggle : MonoBehaviour
{
    public KeyCode keyBind;
    public AudioSource gameAudio;
    public GameObject pauseUI;
    public GameObject scoreboard;
    public bool pauseDoubleCheck = false;

    void Update()
    {
        if (pauseDoubleCheck == true)   // teostab pausi topeltkontrolli j2rgmisel "tickil", 
        {                               // et v2ltida pausi mittetekkimist kui leveli alustamiseks vajutatakse suvalise klahvina seda nuppu, mis m2ngu pausile paneb
            gameAudio.Pause();          // paneb muusika pausile
            Time.timeScale = 0;         // paneb m2ngu (aja) pausile
            pauseUI.SetActive(true);    // muutab pausimenyy kasutajale n2htavaks
            pauseDoubleCheck = false;   // muutab topeltkontrolli sattumise tingimuse tagasi 0i
        }
        if (Input.GetKeyDown(keyBind) && !scoreboard.activeInHierarchy) // kui vajutatakse pausile panemise nuppu ja skooritabel pole stseenis n2htaval (ehk level pole l2bi)
        {
            if (Time.timeScale == 1)                                    // kui m2ng pole pausil
            {
                pauseDoubleCheck = true;                                // m22rab pausi topeltkontrolli p22semiseks m6eldud muutuja 1 peale
                gameAudio.Pause();                                      // paneb muusika pausile
                Time.timeScale = 0;                                     // paneb m2ngu (aja) pausile
                pauseUI.SetActive(true);                                // muutab pausimenyy kasutajale n2htavaks
            }
            else
            {
                Time.timeScale = 1;                                     // katkestab m2ngu (aja) pausi
                gameAudio.Play();                                       // paneb muusika edasi m2ngima
                pauseUI.SetActive(false);                               // peidab pausimenyy
            }
        }
    }
}
