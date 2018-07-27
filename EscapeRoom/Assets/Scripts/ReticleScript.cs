using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleScript : MonoBehaviour {
	//public GameObject reticle;
	public Camera CameraFacing;
	[HideInInspector]
	public enum ReticleStates{
		Selected,
		Holding,
		Open
	};
    ReticleStates state;
	[HideInInspector]
	public ReticleStates RS; 

	bool isSelected = false;
	Renderer r;
	float distance;
	Vector3 originalScale;
	RaycastHit hit;
    public Color selected;
    public Color moving;
    public Color open;
    public MeshRenderer hand;

	// Use this for initialization
	void Start () {
		
		originalScale = transform.localScale;
		r = this.gameObject.GetComponent<Renderer> ();
        state = ReticleStates.Open;

	}
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(new Ray(CameraFacing.transform.position,
            CameraFacing.transform.rotation * Vector3.forward),
            out hit))
        {
            distance = hit.distance;
            UpdateReticleState();
        }
        else
        {
            state = ReticleStates.Open;
            distance = 100.0f; //if it hits nothing set to default distance
        }
        transform.position = CameraFacing.transform.position + CameraFacing.transform.rotation * Vector3.forward * distance;
        transform.LookAt(CameraFacing.transform.position);
        transform.Rotate(0.0f, 180.0f, 0.0f);
        if (distance < 10.0f)
        {
            distance *= 1 + 5 * Mathf.Exp(-distance);
        }
        transform.localScale = originalScale * distance * 0.05f;
        if (state == ReticleStates.Selected)
        {
            r.material.color = selected;
            DisplayHand(true);
        }
        else if (state == ReticleStates.Holding) {
            r.material.color = moving;
            if (Input.GetButton("Tap"))
            {
                hit.collider.gameObject.GetComponent<MovePieces>().isSelected = true;
            }
        }
        else
        {
            r.material.color = open;
            DisplayHand(false);
        }
            

	}

	public void UpdateReticleState(){

        if (hit.collider.tag == "Selectable")
            state = ReticleStates.Selected;
        else if (hit.collider.tag == "Movable")
            state = ReticleStates.Holding;
        else
            state = ReticleStates.Open;        
    }

    void DisplayHand(bool isActive)
    {
        if (hand.enabled == !isActive)
            hand.enabled = isActive;
    }
}
