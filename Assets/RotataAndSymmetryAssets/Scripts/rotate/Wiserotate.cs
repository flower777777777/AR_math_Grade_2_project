using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiserotate : MonoBehaviour {
    float xSpeed = 300.0f;
    public GameObject obj;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            if (Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    transform.RotateAround(obj.transform.position, Vector3.up * Input.GetAxis("Mouse X"), -xSpeed * Time.deltaTime);
                }
            }
        }
    }
}
