using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class Rotate : MonoBehaviour {
    float xSpeed = 150.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponentInChildren<Outline>().enabled == true)
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.touchCount == 1)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * -xSpeed * Time.deltaTime, Space.World);
                    }
                }
            }
        }
	}
}
