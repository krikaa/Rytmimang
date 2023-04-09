using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class  MouseDetection: MonoBehaviour
{

    public int leftMouseButton = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(leftMouseButton))
        {
            Debug.Log("Left mouse button clicked!");
        }
    }
}
