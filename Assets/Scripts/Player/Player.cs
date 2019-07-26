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
	public float bullet_speed;
	public GameObject player_missile;
	public int missile_qty;
	private float next_fire;
	public GameObject player_shield;

	private void OnEnable() {
		EventManager.StartListening(Message.UPGRADE_ADDED, UpdateStats);
	}

	private void OnDisable() {
		EventManager.StopListening(Message.UPGRADE_ADDED, UpdateStats);		
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
		if (Globals.Health <= 0) {
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
			float projectile_speed = instantiatedBullet.GetComponent<BulletHandler>().GetSpeed();
			instantiatedBullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectile_speed, 0);
		}

		if (Input.GetButtonDown("Fire2")) {
			if (missile_qty > 0 && Time.time > next_fire) {
				float cooldown = player_missile.GetComponent<BulletHandler>().GetCooldown();
				next_fire = Time.time + cooldown;
				missile_qty--;
				GameObject instantiatedMissile = Utilities.Create(player_missile, this.gameObject);
				float projectile_speed = instantiatedMissile.GetComponent<BulletHandler>().GetSpeed();
				instantiatedMissile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectile_speed * 10, 0);
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.tag == "projectile") {
			BulletHandler bullet = collision.collider.gameObject.GetComponent<BulletHandler>();
			int damage = bullet.GetBulletDamage();
			Globals.PlayerHealth(-damage);
		}
	}

	public void UpdateStats() {
		List<UpgradeData> upgrades = Globals.Upgrades;
		foreach(UpgradeData up in upgrades) {
			float mod = up.UpgradeValue;
			switch (up.ModType) {
				case UpgradeType.SPEED:
					//assign to correct variable
					break;
				case UpgradeType.HEALTH:
					//assign to correct variable
					break;
				case UpgradeType.SHIELD:
					//assign to correct variable
					break;
				case UpgradeType.FIRE_RATE:
					//assign to correct variable
					break;
				default:
					//assign to correct variable
					break;
			}
		}
	}

	void OnSceneLoaded() {
		
	}
}
