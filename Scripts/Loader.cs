using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    private static Scene targetScene;
    public enum Scene
    {
        MainManuScene,
        GameScene,
        LoadingScene,
    }

    public static void Load(Scene targetSceneName)
    {
        Loader.targetScene = targetSceneName;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());

    }
    public static void LoaderCallback()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }
}
