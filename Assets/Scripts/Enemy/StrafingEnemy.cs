using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrafingEnemy : Enemy
{
    public int direction;

    public override void Movement() {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        Vector3 tempVect = new Vector3(direction, 0, 0);
	    tempVect = tempVect.normalized * enemyData.Speed * Time.deltaTime;
	    rb.MovePosition(rb.transform.position + tempVect);
    }
}