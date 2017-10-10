using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public GameObject player;
    public GameObject cameraPivot;

    private bool ending;
    private float timeToEnd;

	// Use this for initialization
	void Start () {
        if(GameObject.Find("Game Manager").GetComponent<GameManager>().GetGameStarted())
        {
            player.SetActive(true);
        }
        if(GameObject.Find("Game Manager").GetComponent<GameManager>().CheckFinished())
        {
            player.GetComponent<PlayerControl>().MakeUncontrollable();
            GameObject.Find("Fade").GetComponent<FadeInOut>().SetAlpha(0.0f);
            GameObject.Find("Fade").GetComponent<FadeInOut>().SetFadeSpeed(0.1f);
            GameObject.Find("Fade").GetComponent<FadeInOut>().Switch();
            cameraPivot.SendMessage("EndGame");
            ending = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //
        if (!GameObject.Find("Game Manager").GetComponent<GameManager>().GetGameStarted())
        {
            if (Input.GetAxisRaw("Fire1") != 0.0f || Input.GetAxisRaw("Jump") != 0.0f)
            {
                GameObject.Find("Game Manager").GetComponent<GameManager>().StartGame();
                cameraPivot.SendMessage("StartGame");
                player.SetActive(true);
            }
        }
        //
        if (ending)
        {
            timeToEnd += Time.deltaTime;
            if(timeToEnd >= 10.0f)
            {
                Application.Quit();
            }
        }
	}
}
