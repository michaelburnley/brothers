using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    [SerializeField]
    private ProjectileData projectileData;

    public int Damage {
        get {
            return projectileData.Damage;
        }
    }

    public float Speed {
        get {
            return projectileData.Speed;
        }
    }

    public float Cooldown {
        get {
            return projectileData.Cooldown;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Destroy(this.gameObject);
    }

}
