using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierHandler : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) {
    	if (collision.collider.tag == "background_sprite" || collision.collider.tag == "enemy" || collision.collider.tag == "projectile") {
    		Debug.Log("Destroyed object.");
    		Destroy(collision.gameObject);
    	}
    }

}
