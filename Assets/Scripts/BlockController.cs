using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] Vector3 moveDistance;
    bool isOpen = false;

    public void OpenGate()
    {
        if(!isOpen)
        {
            transform.position += moveDistance;
            isOpen = true;
        }
    }

    public void CloseGate()
    {
        if(isOpen)
        {
            transform.position -= moveDistance;
            isOpen = false;
        }
    }
}