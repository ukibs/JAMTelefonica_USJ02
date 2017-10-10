using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    //Public
    public float movementSpeed;
    public Transform model;
    //Private
    private float hAxis, vAxis;
    private bool use;
    private CharacterController cc;
    private bool controllable = true;
    private float fallingSpeed = 0.0f;
    private Vector3 initialPos;

	// Use this for initialization
	void Start () {
        cc = gameObject.GetComponent<CharacterController>();
        initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float dt = Time.deltaTime;
        
        if (controllable)
        {
            UpdateGravity(dt);
            UpdateControls();
            UpdateMovement(dt);
            UpdateActions();
        }
	}

    //
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(transform.position + model.transform.forward, 0.5f);
    }

    //
    void UpdateControls()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        use = Input.GetAxisRaw("Fire1") != 0 || Input.GetAxisRaw("Jump") != 0;
    }

    //
    void UpdateGravity(float dt)
    {
        fallingSpeed += 9.81f * dt;
        if (cc.isGrounded) fallingSpeed = 0.0f;
        cc.Move(new Vector3(0.0f, -fallingSpeed * dt, 0.0f));
        if(transform.position.y < -10.0f)
        {
            transform.position = initialPos;
        }
    }

    //
    void UpdateMovement(float dt)
    {
        cc.Move(new Vector3(hAxis * movementSpeed * dt, 0.0f, vAxis * movementSpeed * dt));
        if (hAxis != 0 || vAxis != 0)
        {
            model.rotation = Quaternion.LookRotation(
                new Vector3(hAxis * movementSpeed * dt, 0.0f, vAxis * movementSpeed * dt));
        }
    }

    //
    void UpdateActions()
    {
        if (use)
        {
            //Debug.Log("Raycasting");
            RaycastHit hit;
            if(Physics.Raycast(transform.position, model.transform.forward, out hit, 1.0f))
            {
                //Debug.Log("Searching");
                if(hit.transform.tag == "Interactable")
                {
                    hit.transform.SendMessage("Activate", model.transform.forward);
                    //Debug.Log("Interacting");
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
