using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    int total_scenes = SceneManager.sceneCountInBuildSettings;
    private void OnEnable() {
        EventManager.StartListening(Events.message.NEXT_SCENE, SceneSwitcher);
    }

    private void OnDisable() {
        EventManager.StopListening(Events.message.NEXT_SCENE, SceneSwitcher);
    }

    private void SceneSwitcher () {
        int scene = Globals.Scene();
        if ((scene + 1) < total_scenes) {
            SceneManager.LoadScene(scene);
        }
    }
}
