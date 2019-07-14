using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrafingEnemy : Enemy
{
    public override void Movement() {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        Vector3 tempVect = new Vector3(-10, 0, 0);
	    tempVect = tempVect.normalized * speed * Time.deltaTime;
	    rb.MovePosition(rb.transform.position + tempVect);
    }

    // private void OnCollisionEnter2D(Collision2D collision) {
    //     if (collision.collider.tag == "barrier") {
    //         Debug.Log("Hit Barrier");
    //     }
    // }
}