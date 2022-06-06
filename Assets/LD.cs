using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightScript : MonoBehaviour
{

    public Light mylight;
    // Start is called before the first frame update
    void Start()
    {
        mylight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            mylight.enabled = !mylight.enabled;
        }
    }
}
