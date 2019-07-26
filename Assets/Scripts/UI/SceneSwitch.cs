using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    private int total_scenes;
    private void OnEnable() {
        EventManager.StartListening(Message.NEXT_SCENE, SceneSwitcher);
    }

    private void OnDisable() {
        EventManager.StopListening(Message.NEXT_SCENE, SceneSwitcher);
    }

    private void Awake() {
        total_scenes = SceneManager.sceneCountInBuildSettings;
    }

    private void SceneSwitcher () {
        int scene = Globals.Scene;
        Debug.Log(total_scenes);
        if ((scene + 1) <= total_scenes) {
            Debug.Log("Loading Scene: " + scene);
            SceneManager.LoadScene(scene);
        }
    }
}
