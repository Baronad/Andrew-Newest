using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingRope : MonoBehaviour
{

// wavecount = hur många vågor som linjen som vapnet skjuter ut ska ha 
// även adderat en animation, animationcurve


    private Spring spring;
    private LineRenderer lr;
    public GrapplingGun grapplingGun;
    public int quality;
    private Vector3 currentGrapplePosition;
    public float damper;
    public float strength;
    public float velocity;
    public float waveCount;
    public float waveHeigth;
    public AnimationCurve affectCurve;

    // väcker själva jointen av linjen 

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        spring = new Spring();
        spring.SetTarget(0);
    }

    void LateUpdate()
    {
        DrawRope();
    }

// lr = linerenderer 
// om linjen förstörs av antingen att trycka igen eller av andra omständigheter såsom till exempel buggar 

    void DrawRope()
    {
        if (!grapplingGun.IsGrappling())
        {
            currentGrapplePosition = grapplingGun.gunTip.position;
            spring.Reset();
            if (lr.positionCount > 0)
                lr.positionCount = 0;

            return;
        }

        if (lr.positionCount == 0)
        {
            spring.SetVelocity(velocity);
            lr.positionCount = quality + 1;
        }


        spring.SetDamper(damper);
        spring.SetStrength(strength);
        spring.Update(Time.deltaTime);

// quaternion = rotation, i detta fallet av vapnet och gubben då vi ser lookrotation((grapplepoint - guntipposition)

        var grapplePoint = grapplingGun.GetGrapplePoint();
        var gunTipPosition = grapplingGun.gunTip.position;
        var up = Quaternion.LookRotation((grapplePoint - gunTipPosition).normalized) * Vector3.up;



        currentGrapplePosition = Vector3.Lerp(a: currentGrapplePosition, grapplePoint, Time.deltaTime * 12f);
        
        // beräknat kurvorna på linjerna (vågorna) 

        for (var i = 0; i < quality + 1; i++)
        {
            var delta = i / (float)quality;
            var offset = up * waveHeigth * Mathf.Sin(f: delta * waveCount * Mathf.PI) * spring.Value * affectCurve.Evaluate(delta);

        }
    }
}

