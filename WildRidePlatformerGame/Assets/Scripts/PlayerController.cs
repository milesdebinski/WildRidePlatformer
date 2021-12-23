using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] float torqueAmount = 2500f;
  [SerializeField] float boostSpeed = 21f;
  [SerializeField] float baseSpeed = 14f;
  Rigidbody2D rb2d;
  SurfaceEffector2D surfaceEffector2D;
  bool canMove = true;


  // Start is called before the first frame update
  void Start()
  {
    rb2d = GetComponent<Rigidbody2D>();
    surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();

  }

  // Update is called once per frame
  void Update()
  {
    if (canMove)
    {
      RotatePlayer();
      RespondToBoost();
    }
  }

  public void DisableControls(bool isEnabled)
  {
    canMove = isEnabled;
  }

  void RespondToBoost()
  {
    if (Input.GetKey(KeyCode.UpArrow))
    {
      surfaceEffector2D.speed = boostSpeed;
    }
    else
    {
      surfaceEffector2D.speed = baseSpeed;
    }

    // if we push up then speed up
    // ohterwise stay at normal speed
  }

  void RotatePlayer()
  {
    if (Input.GetKey(KeyCode.LeftArrow))
    {
      rb2d.AddTorque(torqueAmount * Time.deltaTime);
      Debug.Log("xxTORQUE" + torqueAmount);
      Debug.Log("TORQUE + DELTA" + torqueAmount * Time.deltaTime);
    }
    else if (Input.GetKey(KeyCode.RightArrow))
    {
      rb2d.AddTorque(-torqueAmount * Time.deltaTime);
    }
  }


}
