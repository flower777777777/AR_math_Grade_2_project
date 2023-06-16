using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FbtOnClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClick()
    {
        if (!GetComponentInChildren<turnBtOnClick>().getState())
        {
            float speed = Random.Range(800, 1100);
            GetComponentInChildren<turnBtOnClick>().setSpeed(speed);
            GetComponentInChildren<turnBtOnClick>().setState(true);
        }
    }
}
