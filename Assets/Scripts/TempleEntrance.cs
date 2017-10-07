using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempleEntrance : MonoBehaviour {

    //
    public string destination;

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
            SceneManager.LoadScene(destination);
        }
    }
}
