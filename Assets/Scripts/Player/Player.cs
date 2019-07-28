﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public float mod_speed = 0f;
	public float mod_max_speed = 0f;
	public float mod_acceleration = 0f;
	public float mod_deceleration = 0f;

	private Rigidbody2D rb;
	private SpriteRenderer renderer;

	public GameObject player_bullet;
	public GameObject player_missile;
	public float bullet_speed;
	private float next_fire;
	private PlayerState state;

	private void OnEnable() {
		EventManager.StartListening(Message.BOSS_ENCOUNTER, BossEncounter);
		EventManager.StartListening(Message.GAME_OVER, GameOver);
	}

	private void OnDisable() {		
		EventManager.StopListening(Message.BOSS_ENCOUNTER, BossEncounter);		
		EventManager.StopListening(Message.GAME_OVER, GameOver);		
	}

    void Start()
    {
        state = Globals.State;
		renderer = GetComponent<SpriteRenderer>();
		rb = this.GetComponent<Rigidbody2D>();
		UpdateStats();
    }

	public void Update()
	{
		state = Globals.State;
		Movement();
		Shoot();
		CheckHealth();
		if (state.Shield > 0) {
			renderer.sprite = Resources.Load<Sprite>("Sprites/player_with_shield");
		} else {
			renderer.sprite = Resources.Load<Sprite>("Sprites/player");
		}
	}

	public void CheckHealth() {
		if (state.Health <= 0) {
			Globals.GameOver();
		}
	}

	public void Movement() {
	    float h = Input.GetAxis("Horizontal");
	    float v = Input.GetAxis("Vertical");

	    Vector3 tempVect = new Vector3(h, v, 0);

	    tempVect = tempVect.normalized * state.Speed * Time.deltaTime;
	    rb.MovePosition(rb.transform.position + tempVect);
	}

	public void Shoot() {
		if (Input.GetButtonDown("Fire1")) {
			GameObject instantiatedBullet = Utilities.Create(player_bullet, this.gameObject);
			float projectile_speed = instantiatedBullet.GetComponent<BulletHandler>().Speed;
			instantiatedBullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectile_speed, 0);
		}

		if (Input.GetButtonDown("Fire2")) {
			if (state.Missile > 0 && Time.time > next_fire) {
				float cooldown = player_missile.GetComponent<BulletHandler>().Cooldown;
				next_fire = Time.time + cooldown;
				state.Missile = state.Missile - 1;
				GameObject instantiatedMissile = Utilities.Create(player_missile, this.gameObject);
				float projectile_speed = instantiatedMissile.GetComponent<BulletHandler>().Speed;
				instantiatedMissile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectile_speed * 10, 0);
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.tag == "projectile") {
			BulletHandler bullet = collision.collider.gameObject.GetComponent<BulletHandler>();
			state.Health = state.Health - bullet.Damage;
		}
	}

	public void UpdateStats() {
		Debug.Log("Processing upgrades.");
		UpgradeData[] upgrades = state.Upgrades().ToArray();
		foreach(UpgradeData up in upgrades) {
			float modValue = up.UpgradeValue;
			switch (up.ModType) {
				case UpgradeType.SPEED:
					state.Speed = modValue;
					break;
				case UpgradeType.HEALTH:
					state.Health = (int)modValue;
					break;
				case UpgradeType.SHIELD:
					state.Shield = (int)modValue;
					Debug.Log(state.Shield);
					break;
				case UpgradeType.FIRE_RATE:
					state.FireRate = modValue;
					break;
				case UpgradeType.MISSILE:
					state.Missile = (int)modValue;
					break;
				default:
					break;
			}
		}
	}

	public void GameOver() {
		Destroy(this);
	}

	public void BossEncounter() {
		Debug.Log("Starting Boss Encounter.");
	}
}
