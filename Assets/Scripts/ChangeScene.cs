using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private void Awake()
    {
        LoadScene("StoryTeller");
    }

    public static void LoadScene(string scene)
    {
       SceneManager.LoadScene(scene, LoadSceneMode.Additive);
    }

    public static void Unloaded(string scene)
    {
        SceneManager.UnloadSceneAsync(scene);
    }
}
