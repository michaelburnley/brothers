using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade", order = 51)]
public class UpgradeData: ScriptableObject {
    [SerializeField]
    private string upgradeName;

    [SerializeField]
    private float cost;

    [SerializeField]
    private float rarity;

    [SerializeField]
    private Sprite icon;

    [TextArea]
    [SerializeField]
    private string description;
    
    [SerializeField]
    private UpgradeType upgradeType;

    [SerializeField]
    private float upgradeValue;

    public float Cost {
        get {
            return cost;
        }
    }

    public float Rarity {
        get {
            return rarity;
        }
    }

    public Sprite Icon {
        get {
            return icon;
        }
    }


    public string UpgradeName {
        get {
            return upgradeName;
        }
    }


    public string Description {
        get {
            return description;
        }
    }

    public UpgradeType ModType {
        get {
            return upgradeType;
        }
    }

    public float UpgradeValue {
        get {
            return upgradeValue;
        }
    }
}
