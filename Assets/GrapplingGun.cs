using UnityEngine;

public class GrapplingGun : MonoBehaviour
{

// linerenderer = linjen som blir när jag skjuter 
// Asignat linjen till en joint 

    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, FirstCam, player;
    private float maxDistance = 100f;
    private SpringJoint joint;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }


//vid knapptryck så startar eller stoppar grapplen

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButton(0))
        {
            StopGrapple();
        }
    }


// om raycast hit eller om linjen träffar någonting så får karaktären en hit.point som sedan gör så att karaktären svingas fram 
// i detta exemplet är allting som är assignat till ground grappleble

    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(origin: FirstCam.position, direction: FirstCam.forward, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();

            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(a: player.position, b: grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;
            
            // linjens värden 

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;

        }
    }
    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }
    
    // ritar linjen i änden av vapnet 


    void DrawRope()
    {
        if (!joint) return;

        lr.SetPosition(index: 0, gunTip.position);
        lr.SetPosition(index: 1, grapplePoint);
    }


    private Vector3 currentGrapplePosition;

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}



