using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePieces : MonoBehaviour {


	public bool isSelected = false;
    public GameObject reticleToFollow;
    Vector3 reticlePos;

	// Use this for initialization
	void Start () {
        reticleToFollow = GameObject.FindObjectOfType<ReticleScript>().gameObject;
    }

	// Update is called once per frames
	void Update () {
        reticlePos = reticleToFollow.transform.position;
		if (isSelected) {
            //highlight object
            this.transform.localPosition = new Vector3(reticlePos.x, reticlePos.y, 0);
		}			
	}


}
