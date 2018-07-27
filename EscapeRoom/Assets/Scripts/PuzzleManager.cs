using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour {
    private GetPiece[] gp;
    public bool isSolved;

    public Canvas dialog;
    LoadPuzzle puzzlePieces;
    // Use this for initialization
   
    void Start () {
        isSolved = false;
        puzzlePieces = GameObject.FindObjectOfType<LoadPuzzle>();
        gp = GameObject.FindObjectsOfType<GetPiece>();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update () {
        if(isSolved == false)
        {
            isSolved = CheckIfSolved();
        }
            
    }
    
    bool CheckIfSolved()
    {
        if (gp.Length == 0)
            return false;
        else
        {
            foreach (GetPiece g in gp)
            {
                if (!g.isPlaced)
                {
                    return false;
                }

            }
        }
        dialog.enabled = true;
        return true;
    }

    public void OnSceneChanged()
    {
        puzzlePieces = GameObject.FindObjectOfType<LoadPuzzle>();
        if (isSolved && puzzlePieces.enabled == true)
            puzzlePieces.enabled = false;
    }


}
