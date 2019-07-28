using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public SceneData[] sceneData;
    private int total_scenes;
    [SerializeField]
    private GameObject enemies;

    private bool bossCreated = false;

    private void OnEnable() {
        EventManager.StartListening(Message.NEXT_SCENE, SceneSwitcher);
    }

    private void OnDisable() {
        EventManager.StopListening(Message.NEXT_SCENE, SceneSwitcher);
    }

    private void Awake() {
        total_scenes = sceneData.Length;
    }

    private void Update() {
        if (enemies) {
            if (enemies.transform.childCount == 0 && Globals.state.Health > 0 && bossCreated == false) {
                Globals.BossEncounter(sceneData[Globals.Scene].Boss);
                bossCreated = true;
            }
        }
    }

    private void SceneSwitcher () {
        int scene = Globals.Scene;
        // Debug.Log(total_scenes);
        // if ((scene + 1) <= total_scenes) {
        //     Debug.Log("Loading Scene: " + scene);
        //     SceneManager.LoadScene(scene);
        // }
    }

    private void Deserialize () {

    }
}