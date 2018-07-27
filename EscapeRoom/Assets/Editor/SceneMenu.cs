using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneMenu : MonoBehaviour
{

    // Use this for initialization
    [MenuItem("Scenes/Main")]
    static void OpenStartUp()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/ER1.unity");
    }
    [MenuItem("Scenes/LightsOff")]
    static void OpenMainMenu()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/ER2.unity");
    }

    [MenuItem("Scenes/Jigsaw")]
    static void OpenWorld()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Jigsaw.unity");
    }
}