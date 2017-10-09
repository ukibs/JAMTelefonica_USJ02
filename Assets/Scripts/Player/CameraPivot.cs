using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour {

    public GameObject player;
    //Private
    //private Transform player;
    private Vector3 dirToLerp;

    // Use this for initialization
    void Start () {
        //player = GameObject.Find("Player").GetComponent<Transform>();
        //player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        //transform.position = player.position;
        transform.position = player.transform.position;
        //
        if(dirToLerp != Vector3.zero)
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, dirToLerp, 0.1f);
        }
    }

    //
    public void SetRotationToLerp(Vector3 dirToLerp)
    {
        this.dirToLerp = dirToLerp;
    }
}
