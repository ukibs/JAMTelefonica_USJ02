using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyFloating : MonoBehaviour {

    //Public
    public Transform head, body;
    public Transform[] rings;
    public float headSpeed = 0.08f, bodySpeed = 0.07f, ringSpeed = 1.0f, maxHeadOffset = 0.0015f, maxBodyOffset = 0.003f;

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
        head.position += new Vector3(0.0f, hDirection * headSpeed * Time.deltaTime, 0.0f);
        body.position += new Vector3(0.0f, bDirection * bodySpeed * Time.deltaTime, 0.0f);

        //
        if(Mathf.Abs(head.localPosition.y - hInitialPos.y) > maxHeadOffset)
        {
            hDirection *= -1;
        }
        if (Mathf.Abs(body.localPosition.y - bInitialPos.y) > maxBodyOffset)
        {
            bDirection *= -1;
        }
        //Debug.Log(Mathf.Abs(head.localPosition.y - hInitialPos.y) + " " + Mathf.Abs(body.localPosition.y - bInitialPos.y));

        //Rings
        rings[0].Rotate(0.0f, ringSpeed, 0.0f);
        rings[1].Rotate(0.0f, -ringSpeed, 0.0f);
        rings[2].Rotate(0.0f, ringSpeed, 0.0f);
    }
}
