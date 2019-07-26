using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
  [SerializeField]
  public BackgroundData backgroundData;

  private Rigidbody2D rb;

	private void OnEnable() {
		EventManager.StartListening(Message.GAME_OVER, StopMovement);
	}

	private void OnDisable() {
		EventManager.StopListening(Message.GAME_OVER, StopMovement);		
	}

  private void Awake() {
    rb = GetComponent<Rigidbody2D>();
    GetComponent<SpriteRenderer>().sprite = backgroundData.Background;
  }

  private void Start() {
    rb.velocity = new Vector2(0, -backgroundData.Speed);
    Globals.BackgroundSpeed = backgroundData.Speed;
  }

  void Update()
  {
    if (transform.position.y < -backgroundData.Position) {
      RepositionBackground();
    }
  }

  void StopMovement() {
    rb.velocity = Vector2.zero;
  }

  void RepositionBackground() {
    Vector2 backgroundOffset = new Vector2(0, backgroundData.Offset);
    transform.position =  (Vector2) transform.position + backgroundOffset;
  }
}