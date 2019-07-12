using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierHandler : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnCollisionEnter2D(Collision2D collision) {

    	if (collision.collider.tag == "background_sprite" || collision.collider.tag == "enemy" || collision.collider.tag == "projectile") {
    		Debug.Log("Destroyed object.");
    		Destroy(collision.gameObject);
    	}
    }

}
