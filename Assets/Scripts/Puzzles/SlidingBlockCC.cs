using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingBlockCC : MonoBehaviour {

    //
    private CharacterController cc;
    private Vector3 forwardToMove;
    private bool active, falling;
    private float originalY;

	// Use this for initialization
	void Start () {
        cc = gameObject.GetComponent<CharacterController>();
        originalY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (active)
        {
            cc.Move(forwardToMove * 2.0f * Time.deltaTime);
      
        }
        if (falling)
        {
            transform.Translate(Vector3.down * 2.0f * Time.deltaTime);
            if(originalY - transform.position.y > 0.5f)
            {
                falling = false;
            }
        }
	}

    //
    void Activate(Vector3 forwardToApply)
    {
        forwardToMove = forwardToApply;
        //rb.velocity = forwardToApply * 2.0f;
        //rb.isKinematic = false;
        active = true;
    }

    //
    void Deactivate()
    {
        //rb.isKinematic = true;
        forwardToMove = Vector3.zero;
        active = false;
    }

    //
    void OnCollisionEnter(Collision collision)
    {
        Deactivate();
    }

    //
    void StartFalling()
    {
        //rb.isKinematic = true;
        forwardToMove = Vector3.zero;
        falling = true;
    }
}
