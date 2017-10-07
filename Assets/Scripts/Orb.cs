using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Orb : MonoBehaviour {

    //
    private float direction = 1;
    private float initialPosY;

	// Use this for initialization
	void Start () {
        initialPosY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        //
        transform.position += new Vector3(0.0f, direction * 0.1f * Time.deltaTime, 0.0f);

        //
        if (Mathf.Abs(transform.position.y - initialPosY) > 0.1f)
        {
            direction *= -1;
        }

        //Rings
        transform.Rotate(0.0f, 1.0f, 0.0f);
    }

    //
    public void Activate()
    {
        SceneManager.LoadScene("CentralPlace");
    }
}
