/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;
using UnityEngine.UI;

/// <summary>
///     A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    public GameObject perfabs;
    public GameObject button;
    GameObject button1;
    AudioSource audioP;
    public bool isGet;

    #region PROTECTED_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;

    #endregion // PROTECTED_MEMBER_VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        audioP = null;
        button1 = null;
        isGet = false;
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        if (GetComponent<AudioSource>() != null)
        {
            var audioArray = GetComponents(typeof(AudioSource));
            audioP = (AudioSource)audioArray[0];
        }
        if(GetComponent<JudgeBtOnClick>() != null && GetComponent<JudgeBtOnClick>().button1 != null)
        {
            button1 = GetComponent<JudgeBtOnClick>().button1;
        }
    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NOT_FOUND)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PROTECTED_METHODS

    protected virtual void OnTrackingFound()
    {
        isGet = true;
        GameObject obj = GameObject.Instantiate(perfabs, transform.position + new Vector3(0, 0.27f, 0), perfabs.transform.rotation);
        obj.transform.localScale = perfabs.transform.localScale;
        obj.transform.parent = this.transform;
        if(GameObject.Find("turntable_prefab(Clone)") != null && button != null)
        {
            button.SetActive(true);
        }
        if(GameObject.FindGameObjectWithTag("Symmetry") != null && button != null)
        {
            button.SetActive(true);
        }
        if(GameObject.FindGameObjectWithTag("Judge") != null && button != null)
        {
            button.SetActive(true);
        }
        if (audioP != null) audioP.Play();
    }


    protected virtual void OnTrackingLost()
    {
        string name = perfabs.gameObject.name;
        Destroy(GameObject.Find(name + "(Clone)"));
        if (GameObject.Find(name + "11") != null) Destroy(GameObject.Find(name + "11"));
        if (GameObject.Find(name + "12") != null) Destroy(GameObject.Find(name + "12"));
        if (GameObject.Find(name + "13") != null) Destroy(GameObject.Find(name + "13"));
        if (GameObject.Find(name + "14") != null) Destroy(GameObject.Find(name + "14"));
        if (GameObject.Find(name + "Half(Clone)") != null) Destroy(GameObject.Find(name + "Half(Clone)"));
        if (GameObject.Find(name + "Half11") != null) Destroy(GameObject.Find(name + "Half11"));
        if (GameObject.Find(name + "Half12") != null) Destroy(GameObject.Find(name + "Half12"));
        if (GameObject.Find(name + "Half13") != null) Destroy(GameObject.Find(name + "Half13"));
        if (GameObject.Find(name + "Half14") != null) Destroy(GameObject.Find(name + "Half14"));
        if (GameObject.Find("turntable_prefab(Clone)") == null && button != null)
        {
            button.SetActive(false);
        }
        if(GameObject.FindGameObjectWithTag("Symmetry") == null && button != null)
        {
            button.SetActive(false);
        }
        if (GameObject.FindGameObjectWithTag("Judge") == null && button != null)
        {
            button.SetActive(false);
        }
        if (button1 != null) button1.SetActive(false);
        if (audioP != null) audioP.Stop();
        isGet = false;
    }
    
    #endregion // PROTECTED_METHODS
}
