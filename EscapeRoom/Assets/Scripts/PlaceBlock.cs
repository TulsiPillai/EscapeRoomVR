using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBlock : MonoBehaviour {
    public GameObject parentBlock;
    bool triggerEntered;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (triggerEntered && Input.GetButton("Tap"))
            this.transform.localPosition = Vector3.zero;
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
}
