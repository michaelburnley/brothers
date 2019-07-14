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

	private List<Upgrade> upgrades = new List<Upgrade>();

	// Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

	public void Update()
	{
		Movement();
		Shoot();
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
			GameObject instantiatedBullet = Instantiate(player_bullet, (transform.position + new Vector3(0, 1, 0)), transform.rotation);
			instantiatedBullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10, 0);
		}

		if (Input.GetButtonDown("Fire2")) {
			GameObject instantiatedBullet = Instantiate(player_bullet, (transform.position + new Vector3(0, 1, 0)), transform.rotation);
			instantiatedBullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10, 0);
		}
	}

	public void UpdateStats() {
		foreach(Upgrade up in upgrades) {
			up.UpdateStats(this);
		}
	}

	public void AddUpgrade(Upgrade up) {
		upgrades.Add(up);
	}

	void OnSceneLoaded() {
		
	}
}
