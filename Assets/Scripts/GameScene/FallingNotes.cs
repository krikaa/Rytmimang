using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingNotes : MonoBehaviour
{
    public float beatMapTempo;
    public float beatsPerSecond = 0;
    public bool startLevel;

    // Start is called before the first frame update
    void Start()
    {
                  
    }

    // Update is called once per frame
    void Update()
    {
        if (beatsPerSecond == 0)
        {
            beatsPerSecond = beatMapTempo / 60f;    // arvutab loo tempo
        }
        if(!startLevel)
        {
            /*if(Input.anyKeyDown)
            {
                startLevel = true;
            }*/
        }
        else
        {
            transform.position -= new Vector3(0f, 2 * beatsPerSecond * Time.deltaTime, 0f);       // arvutab noodi liikumiskiiruse m66da y-telge
        }
    }
}
