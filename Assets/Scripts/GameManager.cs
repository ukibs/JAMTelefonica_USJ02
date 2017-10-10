using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //
    private bool[] takenOrbs;
    private bool gameStarted;
    //
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start () {
        takenOrbs = new bool[4];
        Cursor.visible = false;
        SceneManager.LoadScene("CentralPlace");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.O)){
            takenOrbs[0] = true;
            takenOrbs[1] = true;
            takenOrbs[2] = true;
            takenOrbs[3] = true;
        }
	}

    //
    public bool CheckTakenOrb(int orbNum)
    {
        return takenOrbs[orbNum];
    }

    //
    public void SaveTakenOrb(int orbNum)
    {
        takenOrbs[orbNum] = true;
    }

    //
    public void StartGame()
    {
        gameStarted = true;
    }

    //
    public bool GetGameStarted()
    {
        return gameStarted;
    }

    //
    public bool CheckFinished()
    {
        return takenOrbs[0] && takenOrbs[1] && takenOrbs[2] && takenOrbs[3];
    }
}
