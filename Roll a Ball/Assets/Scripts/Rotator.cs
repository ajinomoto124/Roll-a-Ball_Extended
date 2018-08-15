using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    //public float bounceType = 1;
    //private float bounceIncrement = 0.02f;
    //private float maxDelta = 0.12f;
    //private float deltaBounce = 0.0f;
    //private bool bouncingUp = true;
    private float maxHeight = 1.6f;
    private float minHeight = .5f;
    public float speed;

    // Update is called once per frame
    void Update () {
        //if (bounceType == 0)
        //{
        //    bounce();
        //}
        //else
        //{
        bounceWithSine();
        //}

        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime); //Because 45 degrees is a lot to rotate per frame, deltaTime shrinks that by an amount relative to time between frames
	}

    void bounceWithSine()
    {
        float hoverHeight = (maxHeight + minHeight) / 2.0f; //This is actually the average/center height of the wave
        float hoverRange = maxHeight - minHeight; //This needs to be divided by two since Sin is (-1,1) instead of (0,1)
        //Debug.Log("T Up: "+transform.up+" V up: "+Vector3.up);
        float curve = Mathf.Sin(Time.time * speed); //The speed accelerates the Time value further down the x-axis.  Time.time is forever increasing unlike deltatime which remains constant
        this.transform.position = new Vector3(transform.position.x, (hoverHeight + ((curve * hoverRange)/2)), transform.position.z); //You can't use Vector3.up because that resets the x and z to center
        //this.transform.position = transform.up * (hoverHeight + ((curve * hoverRange) / 2));
}


    //Obsolete functional version
    //void bounce()
    //{
    //    if (bouncingUp && deltaBounce < maxDelta)
    //    {
    //        deltaBounce = deltaBounce + bounceIncrement;
    //    }
    //    else if (!bouncingUp && deltaBounce > -maxDelta)
    //    {
    //        deltaBounce = deltaBounce - bounceIncrement;
    //    }
    //    else
    //    {
    //        bouncingUp = !bouncingUp;
    //    }
    //    Debug.Log("currentBounce = " + deltaBounce + " and Position is: "+transform.position.y);
    //    Vector3 deltaPos = new Vector3(0, deltaBounce, 0);

    //    deltaPos = (deltaPos + transform.position);

    //    transform.position = deltaPos;
    //}
}
