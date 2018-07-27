using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPiece : MonoBehaviour {
	public GameObject ActionObj;
	[HideInInspector]
	public MovePieces mp;
	public bool isPlaced;

	// Use this for initialization
	void Start () {
        if(ActionObj.tag == "Movable")
		    mp = ActionObj.gameObject.GetComponent<MovePieces> ();
	}
	
	// Update is called once per frame


	void OnTriggerEnter(Collider coll){
		if(coll.gameObject == ActionObj)
        {
            //correct piece
            mp.isSelected = false;
            coll.gameObject.transform.position = this.transform.position;
            isPlaced = true;
        }
			
	}
}
