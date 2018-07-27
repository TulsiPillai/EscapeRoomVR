using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public Scene currentScene;
    PuzzleManager pl;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Use this for initialization
    void Start () {
        pl = GameObject.FindObjectOfType<PuzzleManager>();
	}

    public void LoadMainScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadPuzzleScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadDarkScene()
    {

        SceneManager.LoadScene(2);
    }
    private void Update()
    {
        if (Input.GetButton("Cancel"))
            Application.Quit();
        if (currentScene.name == "ER2" && Input.GetButton("Tap"))
            LoadMainScene();
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        pl = GameObject.FindObjectOfType<PuzzleManager>();
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Jigsaw")
            pl.OnSceneChanged();
    }


}
