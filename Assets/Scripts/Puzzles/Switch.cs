using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public GameObject receptor;

    private bool activated = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //
    private void OnTriggerEnter(Collider other)
    {
        Activate();
    }

    //
    public void Activate()
    {
        if (receptor && !activated)
        {
            receptor.transform.SendMessage("Click");
            activated = true;
            Debug.Log("Activated");
        }
    }
}
