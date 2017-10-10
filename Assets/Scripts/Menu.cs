using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public GameObject player;
    public GameObject cameraPivot;
	public Texture tittle;
	public Texture pressButton;
	public Texture credits;

    private bool ending;
    private bool readyToQuit;
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
            if(timeToEnd >= 5.0f)
            {
                readyToQuit = true;
            }
        }
        //
        if (readyToQuit)
        {
            if(Input.GetAxisRaw("Fire1") != 0.0f && Input.GetAxisRaw("Jump") != 0.0f)
            {
                Application.Quit();
            }
        }
	}

	//
	void OnGUI(){
		if (!GameObject.Find ("Game Manager").GetComponent<GameManager> ().GetGameStarted ())
		{
			GUI.DrawTexture (new Rect (Screen.width/2 - 500, Screen.height/10, 1000, 200), tittle, ScaleMode.ScaleToFit);
			GUI.DrawTexture (new Rect (Screen.width/2 - 500, Screen.height - Screen.height/3, 1000, 200), pressButton, ScaleMode.ScaleToFit);
		}
		if (readyToQuit)
		{
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), credits, ScaleMode.ScaleToFit);
		}
	}
}
