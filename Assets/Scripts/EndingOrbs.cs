using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingOrbs : MonoBehaviour {

    private bool moving;
    private GameObject player;

	// Use this for initialization
	void Start () {
		if(GameObject.Find("Game Manager").GetComponent<GameManager>().CheckFinished())
        {
            moving = true;
        }
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            transform.Translate(0.0f, 0.1f * Time.deltaTime, 0.0f);
            transform.Rotate(0.0f, 30.0f * Time.deltaTime, 0.0f);
            player.transform.Translate(0.0f, 0.1f * Time.deltaTime, 0.0f);
        }
	}
}
