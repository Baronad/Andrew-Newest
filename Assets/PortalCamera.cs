using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portalcamera : MonoBehaviour
{
    public Transform portalOutObj;


    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "portalin")
        {
            GetComponent<Transform>().position = portalOutObj.position;
        }
    }
}

