using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyFloating : MonoBehaviour {

    //Public
    public Transform head, body;

    //Private
    private Vector3 hInitialPos, bInitialPos;
    private int hDirection = -1, bDirection = 1;

	// Use this for initialization
	void Start () {
        hInitialPos = head.localPosition;
        bInitialPos = body.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        //
        head.position += new Vector3(0.0f, hDirection * 0.08f * Time.deltaTime, 0.0f);
        body.position += new Vector3(0.0f, bDirection * 0.07f * Time.deltaTime, 0.0f);
        //
        if(Mathf.Abs(head.localPosition.y - hInitialPos.y) > 0.003f)
        {
            hDirection *= -1;
        }
        if (Mathf.Abs(body.localPosition.y - bInitialPos.y) > 0.003f)
        {
            bDirection *= -1;
        }
        //Debug.Log(Mathf.Abs(head.localPosition.y - hInitialPos.y) + " " + Mathf.Abs(body.localPosition.y - bInitialPos.y));
    }
}
