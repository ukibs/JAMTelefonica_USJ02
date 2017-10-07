using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardinalStream : MonoBehaviour {

    //
    public float streamSpeed = 3.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "Player")
        {
            other.gameObject.GetComponent<PlayerControl>().MakeUncontrollable();
        }
    }

    //
    void OnTriggerStay(Collider other)
    {
        if (other.transform.name == "Player")
        {
            //other.transform.Translate(transform.forward * streamSpeed * Time.deltaTime);
            CharacterController playerCc = other.GetComponent<CharacterController>();
            playerCc.Move(transform.forward * streamSpeed * Time.deltaTime);
            if (other.gameObject.GetComponent<PlayerControl>().GetControllable())
            {
                other.gameObject.GetComponent<PlayerControl>().MakeUncontrollable();
            }
        }
    }

    //
    void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "Player")
        {
            other.gameObject.GetComponent<PlayerControl>().MakeControllable();
        }
    }
}
