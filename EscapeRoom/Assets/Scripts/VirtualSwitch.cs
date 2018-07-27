using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualSwitch : MonoBehaviour {
    bool triggerEntered;
    SceneLoader sl;
    public enum SwitchStates
    {
        LIGHTS_ON,
        LIGHTS_OFF
    };
    public SwitchStates switchStates;
	// Use this for initialization
	void Start () {
        sl = GameObject.Find("SceneMgr").GetComponent<SceneLoader>();
        switchStates = SwitchStates.LIGHTS_ON;
    }

    private void FixedUpdate()
    {
        SetSwitchState();
        if (switchStates == SwitchStates.LIGHTS_ON && Input.GetButton("Tap"))
            sl.LoadDarkScene();
        else if (switchStates == SwitchStates.LIGHTS_ON && Input.GetButton("Tap"))
            sl.LoadMainScene();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            triggerEntered = true;
        else
            triggerEntered = false;

    }
    private void OnTriggerExit(Collider other)
    {
        triggerEntered = false;
    }

    private void SetSwitchState()
    {
        if (triggerEntered && switchStates == SwitchStates.LIGHTS_ON)
            switchStates = SwitchStates.LIGHTS_OFF;
        else if (triggerEntered && switchStates == SwitchStates.LIGHTS_ON)
            switchStates = SwitchStates.LIGHTS_ON;
    }
}
