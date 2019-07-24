using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
  public float scrolling_speed;

  private Vector2 movement;
  public float backgroundPosition;
  private Rigidbody2D rb;

	private void OnEnable() {
		EventManager.StartListening(Events.message.GAME_OVER, StopMovement);
	}

	private void OnDisable() {
		EventManager.StopListening(Events.message.GAME_OVER, StopMovement);		
	}

  private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -scrolling_speed);
  }

  void Update()
  {
    if (transform.position.y < -backgroundPosition) {
      RepositionBackground();
    }
  }

  void StopMovement() {
    Vector2 pause = new Vector2(0, 0);
    rb.velocity = pause;
  }

  void RepositionBackground() {
    Vector2 backgroundOffset = new Vector2(0, 190.5f);
    transform.position =  (Vector2) transform.position + backgroundOffset;
  }
}