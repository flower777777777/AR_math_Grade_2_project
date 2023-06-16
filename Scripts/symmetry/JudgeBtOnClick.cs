using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeBtOnClick : MonoBehaviour {
    bool isJudge;
    bool isGet;
    int option;
    public GameObject half;
    public GameObject button1;
    AudioSource right;
    AudioSource wrong;
    GameObject Button;
    GameObject prefab;
	// Use this for initialization
	void Start () {
        isJudge = false;
        isGet = false;
        option = 0;
        Button = GetComponent<DefaultTrackableEventHandler>().button;
        prefab = GetComponent<DefaultTrackableEventHandler>().perfabs;
        var audioArray = GetComponents(typeof(AudioSource));
        right = (AudioSource)audioArray[1];
        wrong = (AudioSource)audioArray[2];
    }
	
	// Update is called once per frame
	void Update () {
        isGet = GetComponent<DefaultTrackableEventHandler>().isGet;
		if(isJudge)
        {
            if(option == 1)
            {
                if(GetComponentInChildren<IsSymmetry>() != null || GetComponentInChildren<NonSymmetry>() == null)
                {
                    right.Play();
                }
                else if(GetComponentInChildren<NonSymmetry>() != null || GetComponentInChildren<IsSymmetry>() == null)
                {
                    wrong.Play();
                }
            }
            else if(option == 2)
            {
                if (GetComponentInChildren<IsSymmetry>() != null || GetComponentInChildren<NonSymmetry>() == null)
                {
                    wrong.Play();
                }
                else if (GetComponentInChildren<NonSymmetry>() != null || GetComponentInChildren<IsSymmetry>() == null)
                {
                    right.Play();
                }
            }
            Button.SetActive(false);
            if (half != null)
            {
                button1.SetActive(true);
                Destroy(GameObject.Find(prefab.name + "(Clone)"));
                GameObject obj = Instantiate(half, transform.position + new Vector3(0, 0.27f, 0), half.transform.rotation);
                obj.transform.localScale = half.transform.localScale;
                obj.transform.parent = this.transform;
            }
            isJudge = false;
        }
	}

    public void onClickConfirm()
    {
        if (isGet)
        {
            option = 1;
            isJudge = true;
        }
    }

    public void onClickDeny()
    {
        if (isGet)
        {
            option = 2;
            isJudge = true;
        }
    }
}
