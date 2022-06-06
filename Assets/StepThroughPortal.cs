using System.Collections;
using UnityEngine;

public class StepThroughPortal : MonoBehaviour
{

    public GameObject otherPortal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //tells portal that if something hits or collides with portal you will see it on console
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("something hit the portal");
        if (other.tag == "Player")
        {
            other.transform.position = otherPortal.transform.position + otherPortal.transform.forward * 1;
        }
    }
}
