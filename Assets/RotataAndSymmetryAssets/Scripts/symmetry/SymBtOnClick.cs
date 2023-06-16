using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymBtOnClick : MonoBehaviour {
    public GameObject prefab;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void onClickLeft()
    {

        if (GameObject.Find(prefab.name + "1") == null)
        {
            GameObject obj = GameObject.Instantiate(prefab, transform.position - new Vector3(transform.localScale.x, 0, 0), Quaternion.Euler(new Vector3(0, 180f, 0)));
            obj.transform.localScale = transform.localScale;
            obj.transform.parent = this.transform.parent;
            obj.name = prefab.name + "1";
        }
        else
        {
            Destroy(GameObject.Find(prefab.name + "1"));
        }
    }

    public void onClickRight()
    {

        if (GameObject.Find(prefab.name + "2") == null)
        {
            GameObject obj = GameObject.Instantiate(prefab, transform.position + new Vector3(transform.localScale.x, 0, 0), Quaternion.Euler(new Vector3(0, 180f, 0)));
            obj.transform.localScale = transform.localScale;
            obj.transform.parent = this.transform.parent;
            obj.name = prefab.name + "2";
        }
        else
        {
            Destroy(GameObject.Find(prefab.name + "2"));
        }
    }

    public void onClickUp()
    {

        if (GameObject.Find(prefab.name + "3") == null)
        {
            GameObject obj = GameObject.Instantiate(prefab, transform.position + new Vector3(0, 0, transform.localScale.z), Quaternion.Euler(new Vector3(0, 0, 0)));
            obj.transform.localScale = transform.localScale;
            obj.transform.parent = this.transform.parent;
            obj.name = prefab.name + "3";
        }
        else
        {
            Destroy(GameObject.Find(prefab.name + "3"));
        }
    }

    public void onClickDown()
    {

        if (GameObject.Find(prefab.name + "4") == null)
        {
            GameObject obj = GameObject.Instantiate(prefab, transform.position - new Vector3(0, 0, transform.localScale.z), Quaternion.Euler(new Vector3(0, 0, 0)));
            obj.transform.localScale = transform.localScale;
            obj.transform.parent = this.transform.parent;
            obj.name = prefab.name + "4";
        }
        else
        {
            Destroy(GameObject.Find(prefab.name + "4"));
        }
    }
}
