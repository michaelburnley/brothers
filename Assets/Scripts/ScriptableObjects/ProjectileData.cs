using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile", menuName = "Projectile", order = 51)]

public class ProjectileData : ScriptableObject
{

    [SerializeField]
    private int damage;
    [SerializeField]
    private float speed;
	[SerializeField]
    private float cooldown;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private Animator animation;
    // Start is called before the first frame update

    public int Damage {
        get {
            return damage;
        }
    }
    public float Speed {
        get {
            return speed;
        }
    }
    public float Cooldown {
        get {
            return cooldown;
        }
    }
    public Sprite Icon {
        get {
            return icon;
        }
    }
    public Animator Animation {
        get {
            return animation;
        }
    }
}
