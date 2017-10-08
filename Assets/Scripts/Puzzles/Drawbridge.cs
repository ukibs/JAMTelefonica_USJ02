using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawbridge : MonoBehaviour {

    public int switches;
    public float rotatingSpeed = 1.0f;

    private int activatedOnes = 0;
    private bool opened = false;
    private bool moving = false;
    private float amountRotated = 0.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (moving == true)
        {
            //Debug.Log("Moving ");
            Debug.Log(transform.eulerAngles.x);
            transform.Rotate(-rotatingSpeed * Time.deltaTime, 0.0f, 0.0f);
            amountRotated += rotatingSpeed * Time.deltaTime;
            if (amountRotated >= 90.0f)
            {
                moving = false;
                opened = true;
            }
        }
        //Testing
        if (Input.GetKeyDown(KeyCode.P))
        {
            moving = true;
            Debug.Log("Testing activation");
        }
    }

    //
    void CLick()
    {
        activatedOnes++;
        if (activatedOnes == switches)
        {
            moving = true;
        }
    }
}
