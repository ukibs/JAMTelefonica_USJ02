using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingBlock : MonoBehaviour {

    //
	public AudioClip[] slideSounds;

	//
    private Rigidbody rb;
    private Vector3 forwardToMove;
    private bool active, falling;
    private float originalY;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        originalY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (active)
        {
            //transform.Translate(forwardToMove * 2.0f * Time.deltaTime);
      
        }
        if (falling)
        {
            transform.Translate(Vector3.down * 2.0f * Time.deltaTime);
            if(originalY - transform.position.y > 0.5f)
            {
                falling = false;
                transform.DetachChildren();
            }
        }
	}

    //
    void Activate(Vector3 forwardToApply)
    {
        //Debug.Log(forwardToApply.magnitude);
        //if (forwardToApply.magnitude == 1.0f) {
            //GameObject.Find("Player").GetComponent<PlayerControl>().MakeUncontrollable();
            forwardToMove = forwardToApply;
            rb.velocity = forwardToApply * 1.5f;
            rb.isKinematic = false;
            active = true;
		gameObject.GetComponent<AudioSource> ().clip = slideSounds [Random.Range (0, slideSounds.Length)];
		gameObject.GetComponent<AudioSource> ().Play ();

        //}
    }

    //
    void Deactivate()
    {
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        active = false;
        //GameObject.Find("Player").GetComponent<PlayerControl>().MakeControllable();
    }

    //
    void OnCollisionEnter(Collision collision)
    {
        Deactivate();
    }

    //
    void StartFalling()
    {
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        falling = true;
        //GameObject.Find("Player").GetComponent<PlayerControl>().MakeControllable();
    }
}
