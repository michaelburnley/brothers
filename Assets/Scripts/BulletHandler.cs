using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    [SerializeField]
    private ProjectileData projectileData;

    public int GetBulletDamage() {
        return projectileData.Damage;
    }

    public float GetSpeed() {
        return projectileData.Speed;
    }

    public float GetCooldown() {
        return projectileData.Cooldown;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Destroy(this.gameObject);
    }

}
