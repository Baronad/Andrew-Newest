using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPortal : MonoBehaviour
{
    public GameObject leftPortal;
    public GameObject rightPortal;

    GameObject mainCamera;
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    //tells console that if you press right click then it will notify you
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("left click");
            throwPortal(leftPortal);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("right click");
            throwPortal(rightPortal);
        }

        //int x = the aim for the portal is divided by 2 on the screen so it is in the middle, same goes for y 
        void throwPortal(GameObject portal)
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;

            //if you put the portal on an unadjust spot then it will transform for that spots position
            if (Physics.Raycast(ray, out hit))
            {
                Quaternion hitObjectRotation = Quaternion.LookRotation(hit.normal);
                portal.transform.position = hit.point;
                portal.transform.rotation = hitObjectRotation;
            }
        }
    }
}

