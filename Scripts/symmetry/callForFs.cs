using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callForFs : MonoBehaviour {
    bool isGet;
	// Use this for initialization
	void Start () {
        isGet = false;
	}
	
	// Update is called once per frame
	void Update () {
        isGet = GetComponent<DefaultTrackableEventHandler>().isGet;
	}

    public void onClickRight()
    {
        if(isGet && GetComponentInChildren<SymBtOnClick>() != null)
        {
            GetComponentInChildren<SymBtOnClick>().onClickRight();
        }
    }

    public void onClickLeft()
    {
        if (isGet && GetComponentInChildren<SymBtOnClick>() != null)
        {
            GetComponentInChildren<SymBtOnClick>().onClickLeft();
        }
    }

    public void onClickUp()
    {
        if (isGet && GetComponentInChildren<SymBtOnClick>() != null)
        {
            GetComponentInChildren<SymBtOnClick>().onClickUp();
        }
    }

    public void onClickDown()
    {
        if (isGet && GetComponentInChildren<SymBtOnClick>() != null)
        {
            GetComponentInChildren<SymBtOnClick>().onClickDown();
        }
    }
}
