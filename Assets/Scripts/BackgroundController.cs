using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
  /// Scrolling speed
  public Vector2 scrolling_speed = new Vector2(0, 0);

  /// Moving direction
  public Vector2 scrolling_direction = new Vector2(0, 0);

  /// Movement should be applied to camera
  public bool isLinkedToCamera = false;

  void Update()
  {
    // Movement
    Vector2 movement = new Vector2(
      scrolling_speed.x * scrolling_direction.x,
      scrolling_speed.y * scrolling_direction.y);

    movement *= Time.deltaTime;
    transform.Translate(movement);

    // Move the camera
    if (isLinkedToCamera)
    {
      Camera.main.transform.Translate(movement);
    }
  }
}