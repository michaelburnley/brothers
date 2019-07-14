using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float bullet_speed;
    public int score;
    public float health;
    public float bullet_occurence;

    private float timer;

    public GameObject projectile;
    public GameObject shield;

    private void OnEnable() {
    }

    private void OnDisable() {
    }

    void Start()
    {
        
    }

    void Update()
    {
        Movement();
        Shoot();

        if (health <= 0) {
            Globals.ChangeScore(score);
        }
    }

    private void Movement() {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        Vector3 tempVect = new Vector3(0, -10, 0);
	    tempVect = tempVect.normalized * speed * Time.deltaTime;
	    rb.MovePosition(rb.transform.position + tempVect);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Player") {
            Globals.GameOver();
            Destroy(this.gameObject);
        }

        if (collision.collider.tag == "Projectile") {
            BulletHandler bullet = collision.collider.gameObject.GetComponent<BulletHandler>();
            health -= bullet.damage;
        }
    }

    private void Shoot() {
        timer += Time.deltaTime;
        if (timer > bullet_occurence) {
            GameObject instantiatedProjectile = Instantiate(projectile, (transform.position + new Vector3(0, -2, 0)), transform.rotation);
			instantiatedProjectile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10, 0);
            timer = 0;
        }
    }

    private void OnDestroy() {

    }
}
