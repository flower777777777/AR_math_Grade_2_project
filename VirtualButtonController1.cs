using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class VirtualButtonController1 : MonoBehaviour ,IVirtualButtonEventHandler{

	public GameObject Right_1;
	public GameObject Wrong_1;
	// Use this for initialization
	void Start () {
		VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
		for(int i = 0; i < vbs.Length; i++)
		{
			vbs[i].RegisterEventHandler(this);
		}
		Right_1.SetActive(false);
		Wrong_1.SetActive(false);
	}
	public void OnButtonPressed(VirtualButtonBehaviour vb)
	{
		switch (vb.VirtualButtonName)
		{
			case "VirtualButton1":
				Right_1.SetActive(true);
				break;
			case "VirtualButton2":
				Wrong_1.SetActive(true);
				break;
			case "VirtualButton3":
				Wrong_1.SetActive(true);
				break;
			case "VirtualButton4":
				Right_1.SetActive(true);
				break;
		}
	}
	public void OnButtonReleased(VirtualButtonBehaviour vb)
	{
		switch (vb.VirtualButtonName)
		{
			case "VirtualButton1":
				Right_1.SetActive(false);
				break;
			case "VirtualButton2":
				Wrong_1.SetActive(false);
				break;
			case "VirtualButton3":
				Wrong_1.SetActive(false);
				break;
			case "VirtualButton4":
				Right_1.SetActive(false);
				break;
			
		}
	}
	
	
}
