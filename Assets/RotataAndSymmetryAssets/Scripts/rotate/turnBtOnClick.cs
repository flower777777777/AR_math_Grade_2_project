using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turnBtOnClick : MonoBehaviour {
    private float RotateSpeed;
    private bool start;
	// Use this for initialization
	void Start () {
        RotateSpeed = 0;
        start = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (start)
        {
            RotateSpeed -= Time.deltaTime * 100;
            transform.Rotate(Vector3.up * Time.deltaTime * RotateSpeed);
            if (RotateSpeed <= 0)
            {
                start = false;
            }
        }
	}

    public bool getState()
    {
        return this.start;
    }

    public void setSpeed(float val)
    {
        this.RotateSpeed = val;
    }

    public void setState(bool val)
    {
        this.start = val;
    }
}
