using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChecker : MonoBehaviour {

    //
    public Transform[] checkPoints;
    public GameObject conectedDoor;
    public bool eastTemple = false;
    public GameObject generatedLight;
    public GameObject previousMirror;
    public int correctPos;
    public GameObject nextMirror;

    //
    private GameObject block;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (CheckBlock(0))
        {
            Debug.Log("Yep");
            block.transform.position = new Vector3(transform.position.x, block.transform.position.y, transform.position.z);
            block.GetComponent<SlidingBlock>().SendMessage("StartFalling");
            if (conectedDoor)
            {
                conectedDoor.SendMessage("Open");
            }
            if (eastTemple)
            {
                block.transform.GetChild(0).GetComponent<RotatingMirror>().SetParameters(
                    generatedLight, previousMirror, correctPos);
                generatedLight.SetActive(false);
                nextMirror.GetComponent<RotatingMirror>().SetPreviousMirror(block.transform.GetChild(0).gameObject);
                //block.transform.DetachChildren();
            }
        }
	}

    //
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawSphere(transform.position, 0.05f);
        for(int i = 0; i < checkPoints.Length; i++)
        {
            Gizmos.DrawSphere(checkPoints[i].transform.position, 0.05f);
        }
    }

    //
    bool CheckBlock(int checkerNum)
    {
        bool blockDetected = false;
        RaycastHit hit;
        //Debug.Log(checkerNum);
        if (Physics.Raycast(checkPoints[checkerNum].transform.position, transform.up, out hit, 1.0f))
        {
            //Debug.Log(hit.transform.name + " detected");
            if(hit.transform.tag == "Interactable")
            {
                if (checkerNum < checkPoints.Length - 1)
                {
                    blockDetected = CheckBlock(checkerNum + 1);
                }
                else
                {
                    Debug.Log("Finished");
                    block = hit.transform.gameObject;
                    return true;
                }                    
            }
        }
        return blockDetected;
    }
}
