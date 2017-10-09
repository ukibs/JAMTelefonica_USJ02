using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedOrb : MonoBehaviour {

    public int orbNumber;

    private float direction = 1.0f;
    private float initialPosY;

	// Use this for initialization
	void Start () {
        //
        if (GameObject.Find("Game Manager").GetComponent<GameManager>().CheckTakenOrb(orbNumber) == false){
            Destroy(gameObject);
        }
        //
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
}
