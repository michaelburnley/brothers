using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

[CreateAssetMenu(fileName = "New Scene", menuName = "Scene/Scene Data", order = 51)]
public class SceneData : ScriptableObject {

    [SerializeField]
    private string scene_name;

    [SerializeField]
    private int scene_order;

    [SerializeField]
    private GameObject boss;
    
    [SerializeField]
    private UpgradeData[] upgrades = new UpgradeData[3];

    public UpgradeData[] Upgrades {
        get {
            return upgrades;
        }
    }

    public GameObject Boss {
        get {
            return boss;
        }
    }

    public string SceneName {
        get {
            return scene_name;
        }
    }

    public int SceneOrder {
        get {
            return scene_order;
        }
    }
    
}