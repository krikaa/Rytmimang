using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingNotes : MonoBehaviour
{
    public float beatMapTempo;
    public float beatsPerSecond;
    public bool startLevel;

    // Start is called before the first frame update
    void Start()
    {
        beatsPerSecond = beatMapTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startLevel)
        {
            if(Input.anyKeyDown)
            {
                startLevel = true;
            }
        }
        else
        {
            transform.position -= new Vector3(0f, beatsPerSecond * Time.deltaTime, 0f);
        }
    }
}
