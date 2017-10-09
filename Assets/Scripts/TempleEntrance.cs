using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempleEntrance : MonoBehaviour {

    //
    public string destination;
    public GameObject fade;
    public Vector3 dirToLerp;
    public float timeToEnter = 2.0f;

    //
    private bool countStarted;
    private float counterTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (countStarted)
        {
            counterTime += Time.deltaTime;
            if(counterTime >= timeToEnter)
            {
                SceneManager.LoadScene(destination);
            }
        }
	}

    //
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "Player")
        {
            other.GetComponent<PlayerControl>().MakeUncontrollable();
            fade.GetComponent<FadeInOut>().Switch();
            GameObject.Find("CameraPivot").GetComponent<CameraPivot>().SetRotationToLerp(dirToLerp);
            countStarted = true;
        }
    }
}
