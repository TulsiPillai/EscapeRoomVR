using UnityEngine;

public class LoadPuzzle : MonoBehaviour {
    SceneLoader sl;
    PuzzleManager pm;
    bool triggerEntered;
    public bool isSolved;

    // Use this for initialization
    void Start () {
        isSolved = false;
        sl = GameObject.Find("SceneMgr").GetComponent<SceneLoader>();
	}
    private void Update()
    {
        if(triggerEntered && Input.GetButton("Tap"))
            sl.LoadPuzzleScene();        
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
