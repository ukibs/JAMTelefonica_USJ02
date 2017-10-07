using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour {

    //Private
    //private Transform player;
    public GameObject player;

	// Use this for initialization
	void Start () {
        //player = GameObject.Find("Player").GetComponent<Transform>();
        //player = GameObject.Find("Player");

    }
	
	// Update is called once per frame
	void Update () {
        //transform.position = player.position;
        transform.position = player.transform.position;
    }
}
