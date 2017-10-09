using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public int switches;
    public float distanceToMoveDown = 0.1f;
    public float movingSpeed = 0.1f;

    private int activatedOnes = 0;
    private bool moving = false;
    private float originalY;

	// Use this for initialization
	void Start () {
        originalY = transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
		if(moving == true)
        {
            Debug.Log("Moving");
            transform.Translate(0.0f, -movingSpeed * Time.deltaTime, 0.0f);
            if(originalY - transform.position.y > distanceToMoveDown)
            {
                moving = false;
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
        if(activatedOnes == switches)
        {
            moving = true;
        }
    }
}
