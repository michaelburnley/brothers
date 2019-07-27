using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossData", menuName = "Boss", order = 51)]
public class BossData : ScriptableObject {
    [SerializeField]
    private string bossName;
    [SerializeField]
    private int health;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private UpgradeData[] upgrades;
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private int score;
    [SerializeField]
    private float bullet_speed;
    [SerializeField]
    private float bullet_occurence;
    [SerializeField]
    private float cooldown; 
    [SerializeField]
    [TextArea]
    private string speechText;

    public string BossName {
        get {
            return bossName;
        }
    }
    public int Health {
        get {
            return health;
        }
    }
    public GameObject Projectile {
        get {
            return projectile;
        }
    }
    public UpgradeData[] Upgrades {
        get {
            return upgrades;
        }
    }
    public Sprite Sprite {
        get {
            return sprite;
        }
    }
    public int Score {
        get {
            return score;
        }
    }
    public float BulletSpeed {
        get {
            return bullet_speed;
        }
    }
    public float BulletOccurence {
        get {
            return bullet_occurence;
        }
    }
    public float Cooldown {
        get {
            return cooldown; 
        }
    }   

    public string SpeechText {
        get {
            return speechText;
        }
    }
}