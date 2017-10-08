using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingMirror : MonoBehaviour {

    //
    private float initialRotation, nextRotation;
    private bool rotating = false;

	// Use this for initialization
	void Start () {
        initialRotation = transform.eulerAngles.y;
        nextRotation = initialRotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (rotating)
        {
            if (transform.eulerAngles.y < nextRotation || transform.eulerAngles.y - nextRotation > 180)
            {
                //Debug.Log(transform.eulerAngles.y + ", " + nextRotation + ", " + (nextRotation - transform.eulerAngles.y));
                transform.Rotate(Vector3.up * 90.0f * Time.deltaTime);                
            }
            else rotating = false;
        }
	}

    //
    public void Activate()
    {
        if (!rotating)
        {
            rotating = true;
            nextRotation += 90.0f;
            if (nextRotation > 360) nextRotation -= 360;
            //Debug.Log("Activated");
        }
    }
}
