using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPauser : Enemy
{
    public override void Movement() {
        if (!isVisible) {
            MoveForward();
        } else {
            
        }
    }

    private void MoveForward() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 tempVect = new Vector3(0, -10, 0);
	    tempVect = tempVect.normalized * enemyData.Speed * Time.deltaTime;
	    rb.MovePosition(rb.transform.position + tempVect);
    }

    public override void Shoot() {
        timer += Time.deltaTime;
        if (timer > enemyData.BulletOccurence) {
            GameObject instantiatedProjectile = Instantiate(enemyData.Projectile, (transform.position + new Vector3(0, -2, 0)), transform.rotation);
			instantiatedProjectile.GetComponent<SpriteRenderer>().flipY = true;
			instantiatedProjectile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -10, 0);
            timer = 0;
        }
    }
}
