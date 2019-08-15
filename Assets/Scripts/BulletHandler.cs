using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    [SerializeField]
    private ProjectileData projectileData;

    private Animation anim;

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

    private void Awake() {
        if (GetComponent<Animation>()) {
            anim = GetComponent<Animation>();
            anim.clip = projectileData.Clip;
        }
    }

    private void Update() {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag != "barrier" && anim) {
            anim.Play();
        }
        Destroy(this.gameObject);
    }

}
