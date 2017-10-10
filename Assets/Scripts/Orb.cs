using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Orb : MonoBehaviour {

    //
    public int orbNumber;
    public GameObject fade;
    public float timeToLeave = 2.0f;
    //
    private float direction = 1;
    private float initialPosY;    

    //
    private bool countStarted;
    private float counterTime;

    // Use this for initialization
    void Start () {
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

        //
        if (countStarted)
        {
            counterTime += Time.deltaTime;
            if (counterTime >= timeToLeave)
            {
                SceneManager.LoadScene("CentralPlace");
            }
        }
    }

    //
    private void OnTriggerEnter(Collider other)
    {
        //if(other)
        Activate();
    }

    //
    public void Activate()
    {
        GameObject.Find("Game Manager").GetComponent<GameManager>().SaveTakenOrb(orbNumber);
        fade.GetComponent<FadeInOut>().Switch();
        countStarted = true;
        
		//
		gameObject.GetComponent<AudioSource>().Play();
    }
}
