using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public EnemyData enemyData;
    private int health;
    private float backgroundSpeed;

    private float timer;

    private void Awake() {
        backgroundSpeed = GameObject.Find("Background (far)").GetComponent<BackgroundController>().scrolling_speed;
        health = enemyData.Health;
        GetComponent<SpriteRenderer>().sprite = enemyData.Icon;
    }

    void Update()
    {
        Movement();
        Shoot();
        CheckHealth();
    }

    protected void CheckHealth() {
        if (enemyData.Health <= 0) {
            Destroy(this.gameObject);
            Globals.ChangeScore(enemyData.Score);
        }
    }

    public virtual void Movement() {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        Vector3 tempVect = new Vector3(0, -10, 0);
	    tempVect = tempVect.normalized * enemyData.Speed * Time.deltaTime;
	    rb.MovePosition(rb.transform.position + tempVect);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "player") {
            Globals.PlayerHealth(-1);
            Globals.GameOver();
            Destroy(this.gameObject);
        }

        if (collision.collider.tag == "projectile") {
            BulletHandler bullet = collision.collider.gameObject.GetComponent<BulletHandler>();
            int damage = bullet.GetBulletDamage();
            health -= damage;
            Destroy(collision.collider.gameObject);
        }

        if (collision.collider.tag == "barrier") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

    protected void Shoot() {
        timer += Time.deltaTime;
        if (timer > enemyData.BulletOccurence) {
            GameObject instantiatedProjectile = Instantiate(enemyData.Projectile, (transform.position + new Vector3(0, -2, 0)), transform.rotation);
			instantiatedProjectile.GetComponent<SpriteRenderer>().flipY = true;
			instantiatedProjectile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -10, 0);
            timer = 0;
        }
    }

    private void OnDestroy() {

    }
}
