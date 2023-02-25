using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public string load;
    public string unload;

    public void LoadScene()
    {
        ChangeScene.LoadScene(load);
        ChangeScene.Unloaded(unload);
    }
}
