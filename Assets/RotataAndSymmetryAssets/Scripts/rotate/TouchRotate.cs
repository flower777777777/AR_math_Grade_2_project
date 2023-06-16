using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate : MonoBehaviour {
    private float xSpeed;
    private Vector3 center;
    private bool isRotate;
    Vector3 startTrans;
    // Use this for initialization
    void Start () {
        xSpeed = 0;
        isRotate = false;
        startTrans = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (isRotate)
        {
            xSpeed -= Time.deltaTime * 100;
            transform.RotateAround(center, Vector3.up, -xSpeed * Time.deltaTime);
            if(xSpeed <= 0)
            {
                isRotate = false;
            }
        }
    }

    public bool getState() { return this.isRotate; }

    public void setSpeed(float val) { this.xSpeed = val; }

    public void setState(bool val) { this.isRotate = val; }

    public void setCenter(Vector3 dir) { this.center = dir; }
}
