using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTap : MonoBehaviour {
    private float touchtime;
    private bool newTouch;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo))
            {
              
                if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    if(Input.GetTouch(0).tapCount == 2)
                    {
                        Destroy(hitInfo.collider.gameObject);
                    }
                }

                /*
                if(Input.touchCount == 1)
                {
                    Touch touch = Input.GetTouch(0);

                    if(touch.phase == TouchPhase.Began)
                    {
                        newTouch = true;
                        touchtime = Time.time;
                    }
                    else if(touch.phase == TouchPhase.Stationary)
                    {
                        if(newTouch == true && Time.time - touchtime > 1f)
                        {
                            newTouch = false;
                            Destroy(hitInfo.collider.gameObject);
                        }
                    }
                    else
                    {
                        newTouch = false;
                    }
                }*/
            }
        }
	}
}
