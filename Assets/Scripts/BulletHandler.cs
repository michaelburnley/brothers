using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    [SerializeField]
    private ProjectileData projectileData;
    private SpriteRenderer renderer;

    private Animator anim;
    public GameObject spawner;

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
        if (GetComponent<Animator>()) {
            anim = GetComponent<Animator>();
            anim.runtimeAnimatorController = projectileData.Animation;
        }
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        Movement();
    }

    private void Movement() {
        transform.position += transform.up * Time.deltaTime * this.Speed;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "barrier") {
            Destroy(gameObject);
        } else {
            anim.SetBool("destroyed", true);
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Destroy(this.gameObject, 1f);
        }
    }
    

}
