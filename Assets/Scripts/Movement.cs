using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Movement : MonoBehaviour
{
   public float speed = 2f;
   private Rigidbody rbPlayer;

   private Vector2 turn;
   private float sensitivity = 2f;

   private void Start()
   {
      rbPlayer = GetComponent<Rigidbody>();
      Cursor.lockState = CursorLockMode.Locked;
   }

   private void FixedUpdate()
   {
      //Rotate left and right with the mouse.
      turn.x += Input.GetAxis("Mouse X") * sensitivity;
      transform.localRotation = Quaternion.Euler(0, turn.x, 0);

      float uD = Input.GetAxisRaw("Horizontal");
      float lR = Input.GetAxisRaw("Vertical");
      Vector3 movement = transform.forward * lR + transform.right * uD;

      if (movement == Vector3.zero)
      {
         return;
      }
      rbPlayer.MovePosition(rbPlayer.position + movement * (speed * Time.deltaTime));
      
   }
}
