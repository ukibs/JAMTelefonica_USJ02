using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public int switches;
    public float distanceToMoveDown = 0.1f;
    public float movingSpeed = 0.1f;
    public GameObject[] thingsToTransparent;

    private int activatedOnes = 0;
    private bool moving = false;
    private float originalY;
	private LightTivators westAltar;

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
                foreach(GameObject thing in thingsToTransparent)
                {
                    thing.SendMessage("MakeTransparent");
                }
            }
        }
        //Testing
        if (Input.GetKeyDown(KeyCode.P))
        {
            moving = true;
            Debug.Log("Testing activation");
        }
		/*
		// if the switches of the West chamber are all activated, activate the property "LightTivators" on the object
		if(transform.tag=="westAltar")
		{
			if (activatedOnes == switches)
			{
				westAltar = transform.GetComponent<LightTivators> ();
				westAltar.enabled;
			}
		}
		*/
	}

    //
    public void Click()
    {
        activatedOnes++;
        if(activatedOnes == switches)
        {
            moving = true;
        }
    }
}
