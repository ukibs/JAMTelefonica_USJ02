using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTivators : MonoBehaviour {

    private GameObject templeLight;

	// Use this for initialization
	void Start () {
        templeLight = GameObject.Find("TempleLight");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //
    private void OnTriggerStay(Collider other)
    {
        templeLight.GetComponent<FadingLight>().Power();
    }
}
