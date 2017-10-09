using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDoor : MonoBehaviour {

    public GameObject lightToReceive;
    public float distanceToMoveDown = 0.1f;
    public float movingSpeed = 0.1f;
	public GameObject[] thingsToTransparent;

    private bool opened = false;
    private bool moving = false;
    private float originalY;

    // Use this for initialization
    void Start () {
        originalY = transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        if (moving == true)
        {
            Debug.Log("Moving");
            transform.Translate(0.0f, -movingSpeed * Time.deltaTime, 0.0f);
            if (originalY - transform.position.y > distanceToMoveDown)
            {
                moving = false;
                opened = true;

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
        //
        CheckLightToReceive();
    }

    //
    void CheckLightToReceive()
    {
        if(lightToReceive.active == true && opened == false)
        {
            moving = true;
        }
    }
}
