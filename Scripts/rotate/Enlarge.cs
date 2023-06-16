using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class Enlarge : MonoBehaviour {

    Vector2 oldPos1;
    Vector2 oldPos2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount == 2 && this.GetComponentInChildren<Outline>().enabled == true)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                Vector2 temPos1 = Input.GetTouch(0).position;
                Vector2 temPos2 = Input.GetTouch(1).position;

                if(isEnLarge(oldPos1, oldPos2, temPos1, temPos2))
                {
                    float oldScalex = transform.localScale.x;
                    float oldScaley = transform.localScale.y;
                    float oldScalez = transform.localScale.z;

                    transform.localScale = new Vector3(oldScalex * 1.025f, oldScaley, oldScalez * 1.025f);
                }
                else
                {
                    float oldScalex = transform.localScale.x;
                    float oldScaley = transform.localScale.y;
                    float oldScalez = transform.localScale.z;

                    transform.localScale = new Vector3(oldScalex / 1.025f, oldScaley, oldScalez / 1.025f);
                }

                oldPos1 = temPos1;
                oldPos2 = temPos2;
            }
        }
	}

    //判断手势
    bool isEnLarge(Vector2 oP1, Vector2 oP2, Vector2 nP1, Vector2 nP2)
    {
        float length1 = Mathf.Sqrt((oP1.x - oP2.x) * (oP1.x - oP2.x) + (oP1.y - oP2.y) * (oP1.y - oP2.y));
        float length2 = Mathf.Sqrt((nP1.x - nP2.x) * (nP1.x - nP2.x) + (nP1.y - nP2.y) * (nP1.y - nP2.y));

        if(length1 < length2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
