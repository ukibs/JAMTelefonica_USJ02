using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //
    private bool[] takenOrbs;
    //
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start () {
        takenOrbs = new bool[4];
        SceneManager.LoadScene("CentralPlace");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //
    public bool CheckTakenOrb(int orbNum)
    {
        return takenOrbs[orbNum];
    }

    //
    public void SaveTakenOrb(int orbNum)
    {
        takenOrbs[orbNum] = false;
    }
}
