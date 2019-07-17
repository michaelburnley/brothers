using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

	public float speed = 100f;
	public float max_speed = 200f;
	public float acceleration = 10f;
	public float deceleration = 5f;

	public float mod_speed = 0f;
	public float mod_max_speed = 0f;
	public float mod_acceleration = 0f;
	public float mod_deceleration = 0f;

	private Rigidbody2D rb;
	public GameObject player_bullet;
	public GameObject player_missile;
	public GameObject player_shield;

	private void OnEnable() {
		EventManager.StartListening(Events.message.UPGRADE_ADDED, UpdateStats);
	}

	private void OnDisable() {
		EventManager.StopListening(Events.message.UPGRADE_ADDED, UpdateStats);		
	}

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

	public void Update()
	{
		Movement();
		Shoot();
		CheckHealth();
	}

	public void CheckHealth() {
		if (Globals.Health() <= 0) {
			Globals.GameOver();
		}
	}

	public void Movement() {
	    float h = Input.GetAxis("Horizontal");
	    float v = Input.GetAxis("Vertical");

	    Vector3 tempVect = new Vector3(h, v, 0);

	    tempVect = tempVect.normalized * speed * Time.deltaTime;
	    rb.MovePosition(rb.transform.position + tempVect);
	}

	public void Shoot() {
		if (Input.GetButtonDown("Fire1")) {
			GameObject instantiatedBullet = Utilities.Create(player_bullet, this.gameObject);
			instantiatedBullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 20, 0);
		}

		if (Input.GetButtonDown("Fire2")) {
			GameObject instantiatedMissile = Utilities.Create(player_missile, this.gameObject);
			instantiatedMissile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 20, 0);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.tag == "projectile") {
			BulletHandler bullet = collision.collider.gameObject.GetComponent<BulletHandler>();
			Globals.PlayerHealth(-bullet.damage);
		}
	}

	public void UpdateStats() {
		List<Upgrade> upgrades = Globals.Upgrades();
		foreach(Upgrade up in upgrades) {
			up.UpdateStats(this);
		}
	}

	void OnSceneLoaded() {
		
	}
}
