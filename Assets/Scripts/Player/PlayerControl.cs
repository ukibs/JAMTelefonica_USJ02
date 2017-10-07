using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    //Public
    public float movementSpeed;
    public Transform model;
    //Private
    private float hAxis, vAxis, use;
    private CharacterController cc;
    private bool controllable = true;

	// Use this for initialization
	void Start () {
        cc = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (controllable)
        {
            UpdateControls();
            UpdateMovement();
            UpdateActions();
        }
	}

    //
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + model.transform.forward, 0.5f);
    }

    //
    void UpdateControls()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        use = Input.GetAxisRaw("Fire1");
    }

    //
    void UpdateMovement()
    {
        cc.Move(new Vector3(hAxis * movementSpeed * Time.deltaTime, 0.0f, vAxis * movementSpeed * Time.deltaTime));
        if (hAxis != 0 || vAxis != 0)
        {
            model.rotation = Quaternion.LookRotation(
                new Vector3(hAxis * movementSpeed * Time.deltaTime, 0.0f, vAxis * movementSpeed * Time.deltaTime));
        }
    }

    //
    void UpdateOrientation()
    {
        //Aqui giraremos el modelo hacia donde se mueve
    }

    //
    void UpdateActions()
    {
        if (use != 0)
        {
            Debug.Log("Raycasting");
            RaycastHit hit;
            if(Physics.Raycast(transform.position, model.transform.forward, out hit, 1.0f))
            {
                Debug.Log("Searching");
                if(hit.transform.tag == "Interactable")
                {
                    hit.transform.SendMessage("Activate", model.transform.forward);
                    Debug.Log("Interacting");
                }
            }
        }
    }

    //
    public void MakeUncontrollable()
    {
        controllable = false;
    }
    
    //
    public void MakeControllable()
    {
        controllable = true;
    }

    //
    public bool GetControllable()
    {
        return controllable;
    }
}
