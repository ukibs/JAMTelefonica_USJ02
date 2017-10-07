using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChecker : MonoBehaviour {

    //
    public Transform[] checkPoints;

    //
    private GameObject block;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (CheckBlock(0))
        {
            block.transform.position = new Vector3(transform.position.x, block.transform.position.y, transform.position.z);
            block.GetComponent<SlidingBlock>().SendMessage("StartFalling");
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
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up, out hit, 1.0f))
        {
            if(hit.transform.tag == "Interactable")
            {
                if (checkerNum < checkPoints.Length - 1)
                {
                    CheckBlock(checkerNum + 1);
                }
                else
                {
                    block = hit.transform.gameObject;
                    return true;
                }                    
            }
        }
        return false;
    }
}
