using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public GameObject player;
    public GameObject cameraPivot;

	// Use this for initialization
	void Start () {
        if(GameObject.Find("Game Manager").GetComponent<GameManager>().GetGameStarted())
        {
            player.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Fire1")!= 0.0f)
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>().StartGame();
            cameraPivot.SendMessage("StartGame");
            player.SetActive(true);
        }
	}
}
