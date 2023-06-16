using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cakeslice
{
    public class Toggle : MonoBehaviour
    {
        private GameObject obj1;
        private GameObject obj2;
        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    obj1 = hitInfo.collider.gameObject;
                    if (obj1.GetComponent<Outline>() != null)
                    {
                        if (obj2 != null && obj2.transform != obj1.transform && obj2.GetComponent<Rotate>() != null) obj2.GetComponent<Rotate>().enabled = true;
                        if (obj1.GetComponent<Rotate>() != null) {
                            obj1.GetComponent<Rotate>().enabled = false;
                            obj2 = obj1;

                        }
                        else if (obj1.transform.parent.gameObject != null && obj1.transform.parent.gameObject.GetComponent<Rotate>() != null)
                        {
                            obj1.transform.parent.gameObject.GetComponent<Rotate>().enabled = false;
                            obj2 = obj1.transform.parent.gameObject;
                        }
                        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
                        {
                            if (Input.GetTouch(0).tapCount == 1)
                            {
                                Outline[] outlines = obj1.transform.parent.gameObject.GetComponentsInChildren<Outline>();
                                for (int i = 0; i < outlines.Length; i++)
                                {
                                    outlines[i].enabled = !outlines[i].enabled;
                                }
                            }
                        }
                    }
                    else if(obj1.GetComponent<SelectCenter>() != null)
                    {
                        GameObject.Find("gyroscope(Clone)").GetComponentInChildren<TouchRotate>().setCenter(obj1.transform.position);
                        GameObject.Find("gyroscope(Clone)").GetComponentInChildren<TouchRotate>().setState(true);
                        GameObject.Find("gyroscope(Clone)").GetComponentInChildren<TouchRotate>().setSpeed(1000);
                    }
                }
                else if (!Physics.Raycast(ray, out hitInfo) && obj2 != null && obj2.GetComponent<Rotate>() != null)
                {
                    obj2.GetComponent<Rotate>().enabled = true;
                }
            }
            
        }
    }
}