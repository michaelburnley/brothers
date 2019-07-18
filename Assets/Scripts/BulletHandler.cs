using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    public int damage;
    public float speed;
	public float cooldown;
    SpriteRenderer sprite;
    Animator anim;
    
    void OnCollisionEnter2D(Collision2D collision) {
        Destroy(this.gameObject);
        // if (collision.collider.tag == "barrier") {
    	// 	Debug.Log("Destroyed bullet.");
    	// 	Destroy(this.gameObject);
    	// }
        // TODO: Possibly add projectile collission detection
        // if (collision.collider.tag == "projectile") {

        // }
    }

}
