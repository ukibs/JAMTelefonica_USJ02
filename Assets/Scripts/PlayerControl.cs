using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    //Public
    public float movementSpeed;
    public Transform model;
    //Private
    private float hAxis, vAxis;
    private CharacterController cc;

	// Use this for initialization
	void Start () {
        cc = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateControls();
        UpdateMovement();
	}

    //
    void UpdateControls()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
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
}
