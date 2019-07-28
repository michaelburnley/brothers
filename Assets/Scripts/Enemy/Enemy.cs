using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public EnemyData enemyData;
    protected int health;
    protected float backgroundSpeed;

    protected float timer;
    protected bool isVisible = false;

    protected Rigidbody2D rb;

	private void OnEnable() {
		EventManager.StartListening(Message.GAME_OVER, StopShooting);
	}

	private void OnDisable() {
		EventManager.StopListening(Message.GAME_OVER, StopShooting);		
	}

    private void Awake() {
        backgroundSpeed = Globals.BackgroundSpeed;
        health = enemyData.Health;
        rb = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().sprite = enemyData.Icon;
    }

    void Update()
    {
        Movement();
        if (isVisible) {
            Shoot();
        }
        CheckHealth();
    }

    private void OnBecameVisible() {
        isVisible = true;
    }


    protected void CheckHealth() {
        if (health <= 0) {
            Destroy(this.gameObject);
            Globals.ChangeScore(enemyData.Score);
        }
    }

    public virtual void Movement() {
        Vector3 tempVect = new Vector3(enemyData.DirectionX, enemyData.DirectionY, 0);
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
            int damage = bullet.Damage;
            health -= damage;
            Destroy(collision.collider.gameObject);
        }

        if (collision.collider.tag == "barrier") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

    public virtual void Shoot() {
        timer += Time.deltaTime;
        if (timer > enemyData.BulletOccurence) {
            GameObject instantiatedProjectile = Instantiate(enemyData.Projectile, (transform.position + new Vector3(0, -2, 0)), transform.rotation);
			instantiatedProjectile.GetComponent<SpriteRenderer>().flipY = true;
			instantiatedProjectile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, enemyData.DirectionY, 0);
            timer = 0;
        }
    }

    private void StopShooting() {
        Debug.Log("Stopping shooting.");
        timer = 0f;
    }

    private void OnDestroy() {

    }
}
