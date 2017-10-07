using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingBlock : MonoBehaviour {

    //
    private Rigidbody rb;
    private Vector3 forwardToMove;
    private bool active;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (active)
        {
            //transform.Translate(forwardToMove * 2.0f * Time.deltaTime);
      
        }
	}

    //
    void Activate(Vector3 forwardToApply)
    {
        forwardToMove = forwardToApply;
        rb.velocity = forwardToApply * 2.0f;
        rb.isKinematic = false;
        active = true;
    }

    //
    void Deactivate()
    {
        rb.isKinematic = true;
        active = false;
    }

    //
    void OnCollisionEnter(Collision collision)
    {
        Deactivate();
    }
}
