using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour {

    public GameObject player;
    public GameObject gameCamera;
    public Transform cameraMenuPos;
    //Private
    //private Transform player;
    private Vector3 dirToLerp;
    private Vector3 cameraOriginalLPosition;
    private Vector3 cameraOriginalLEulerAngles;
    private bool startingGame;
    private float startingCount;

    // Use this for initialization
    void Start () {
        //
        cameraOriginalLPosition = gameCamera.transform.localPosition;
        cameraOriginalLEulerAngles = gameCamera.transform.localEulerAngles;
        //
        if (player.active == false)
        {
            gameCamera.transform.position = cameraMenuPos.position;
            gameCamera.transform.eulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
        }
    }
	
	// Update is called once per frame
	void Update () {
        //
        if (player.active == true)
        {
            transform.position = player.transform.position;
        }
        else
        {
            transform.Rotate(0.0f, 30.0f * Time.deltaTime, 0.0f);
        }
        //
        if(dirToLerp != Vector3.zero)
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, dirToLerp, 0.1f);
        }
        //
        if (startingGame)
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, Vector3.zero, 0.1f);
            gameCamera.transform.localPosition = Vector3.Lerp(gameCamera.transform.localPosition, cameraOriginalLPosition, 0.1f);
            gameCamera.transform.localEulerAngles = Vector3.Lerp(gameCamera.transform.localEulerAngles, cameraOriginalLEulerAngles, 0.1f);
            //Debug.Log(gameCamera.transform.position + ", " + gameCamera.transform.eulerAngles);
            startingCount += Time.deltaTime;
            if(startingCount > 1.0f)
            {
                startingGame = false;
            }
        }
    }

    //
    public void SetRotationToLerp(Vector3 dirToLerp)
    {
        this.dirToLerp = dirToLerp;
    }

    //
    public void StartGame()
    {
        startingGame = true;
    }
}
