using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	public float speed = 100f;
	public float max_speed = 200f;
	public float acceleration = 10f;
	public float deceleration = 5f;

	public float mod_speed = 0f;
	public float mod_max_speed = 0f;
	public float mod_acceleration = 0f;
	public float mod_deceleration = 0f;

	public Rigidbody2D rb;
	public GameObject player_bullet;
	public GameObject player_missile;
	public GameObject player_shield;

	private List<Upgrade> upgrades = new List<Upgrade>();

	public void Update()
	{
	    float h = Input.GetAxis("Horizontal");
	    float v = Input.GetAxis("Vertical");

	    Vector3 tempVect = new Vector3(h, v, 0);
	    tempVect = tempVect.normalized * (speed + mod_speed) * Time.deltaTime;
	    rb.MovePosition(rb.transform.position + tempVect);
	}

	public void Shoot() {
		// TODO: 
    	// if (KeyCode.Space) {
    	// 	Instantiate(Object original, Vector3 position, Quaternion rotation)
    	// }
	}

	public void UpdateStats() {
		foreach(Upgrade up in upgrades) {
			up.UpdateStats(this);
		}
	}

	public void AddUpgrade(Upgrade up) {
		upgrades.Add(up);
	}
}
