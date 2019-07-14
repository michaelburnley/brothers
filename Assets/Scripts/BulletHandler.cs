using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    public int damage;
    
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "barrier") {
    		Debug.Log("Destroyed bullet.");
    		Destroy(this.gameObject);
    	}
    }

}
