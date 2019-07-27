using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject sceneManager;

    private SceneData sceneData;
    private UpgradeData[] upgradeData;

    private void Awake() {
    }

    private void Start() {
        sceneData = sceneManager.GetComponent<SceneSwitch>().sceneData[Globals.Scene];
        upgradeData = sceneData.Upgrades;

        for (int i = 0; i < upgradeData.Length; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<Upgrade>().upgradeData = upgradeData[i];
        }   
    }
}
