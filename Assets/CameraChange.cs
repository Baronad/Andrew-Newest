using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange: MonoBehaviour
{

    public GameObject ThirdCam;
    public GameObject FirstCam;
    public int CamMode;

    // Update is called once per frame
    void Update()
    {
    
// här har jag satt så att om jag trycker 1 kommer jag in i firstperson, vice versa med thirdperson och 0 

        if (Input.GetButtonDown("Camera"))
        {
            if (CamMode == 1 )
            {
                CamMode = 0;
            }
        else { 
                CamMode += 1;
            }
            
            // En coroutine är tillåter dig att kunna executa olika uppgifter över olika ramar
            
            StartCoroutine (CamChange());
        }

    }
    
     // om kameran är defualt så betyder det 1 
    // om kameran är sekundär / thirdperso så är kameran 0 
    
    IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01f);
        if (CamMode == 0)
        {
            ThirdCam.SetActive(true);
            FirstCam.SetActive(false);
        }
        if (CamMode == 1)
        {
            FirstCam.SetActive(true);
            ThirdCam.SetActive(false);
        }
    }
}
