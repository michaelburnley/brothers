using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy", order = 51)]

public class EnemyData : ScriptableObject {

    [SerializeField]
    private string enemy_name;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private int health;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int score;
    [SerializeField]
    private float bullet_speed;
    [SerializeField]
    private float bullet_occurence;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private GameObject shield;


    public GameObject Projectile {
        get {
            return projectile;
        }
    }

    public GameObject Shield {
        get {
            return shield;
        }
    }

    public float Speed {
        get {
            return speed;
        }
    }
    public float BulletSpeed {
        get {
            return bullet_speed;
        }
    }
    public Sprite Icon {
        get {
            return icon;
        }
    }

    public string EnemyName {
        get {
            return enemy_name;
        }
    }

    public float BulletOccurence {
        get {
            return bullet_occurence;
        }
    } 

    public int Score {
        get {
            return score;
        }
    } 

    public int Health {
        get {
            return health;
        }
    } 
}
