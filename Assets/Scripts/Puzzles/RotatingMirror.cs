using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingMirror : MonoBehaviour {

    //
    public GameObject generatedLight;
    public GameObject previousMirror;
    public int correctPos;

    //
    private float initialRotation, nextRotation;
    private bool rotating = false;
    private bool orientationOk;
    private int currentPos;

	// Use this for initialization
	void Start () {
        initialRotation = transform.eulerAngles.y;
        nextRotation = initialRotation;
        if(generatedLight) generatedLight.SetActive(false);
        if (currentPos == correctPos) orientationOk = true;
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
            else
            {
                rotating = false;
                currentPos++;
                if (currentPos > 3) currentPos = 0;
                if(currentPos == correctPos)
                {
                    if (previousMirror){
                        if (previousMirror.GetComponent<RotatingMirror>().GetOrientationOk()){
                            generatedLight.SetActive(true);
                            orientationOk = true;
                        }
                    }
                    else
                    {
                        generatedLight.SetActive(true);
                        orientationOk = true;
                    }
                }
            }
        }
        //Constant chek for some cases
        if (previousMirror)
        {
            CheckPreviousMirror();
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
            if (orientationOk) orientationOk = false;
            //Debug.Log("Activated");
        }
    }

    //
    public bool GetOrientationOk()
    {
        return orientationOk;
    }

    //
    void CheckPreviousMirror()
    {
        if (previousMirror.GetComponent<RotatingMirror>().GetOrientationOk() && orientationOk)
        {
            generatedLight.SetActive(true);
        }
        else
        {
            generatedLight.SetActive(false);
        }
    }

    //
    public void SetParameters(GameObject generatedLight, GameObject previousMirror, int correctPos)
    {
        this.generatedLight = generatedLight;
        this.previousMirror = previousMirror;
        this.correctPos = correctPos;
    }

    //
    public void SetPreviousMirror(GameObject previousMirror)
    {
        this.previousMirror = previousMirror;
    }
}
