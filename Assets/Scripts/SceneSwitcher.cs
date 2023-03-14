using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string gameSceneName;

    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }

    public void loadGameScene()
    {
        StartCoroutine(LoadAndSetUp());
    }

    IEnumerator LoadAndSetUp()
    {
        SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
        Debug.Log("Load scene started");
        yield return null;
        
        Debug.Log("Scene Loaded");
    }
}
