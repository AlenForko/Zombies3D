using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
   public float speed = 2f;
   public Rigidbody rbPlayer;
   private CapsuleCollider _playerCollider;
   public LayerMask groundLayer;

   private Vector2 turn;
   private float _sensitivity = 2f;

   public Animator animator;
   bool isMoving;

   private void Start()
   {
      _playerCollider = GetComponent<CapsuleCollider>();
      rbPlayer = GetComponent<Rigidbody>();
      Cursor.lockState = CursorLockMode.Locked;
   }

   private void Update()
   {
      isMoving = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
      animator.SetBool("isMoving", isMoving);
   }

   private void LateUpdate()
   {
      //Rotate left and right with the mouse.
      turn.x += Input.GetAxis("Mouse X") * _sensitivity;
      transform.localRotation = Quaternion.Euler(0, turn.x, 0);

      float uD = Input.GetAxisRaw("Horizontal");
      float lR = Input.GetAxisRaw("Vertical");
      Vector3 movement = transform.forward * lR + transform.right * uD;
      
      
      //Make a radius based on the player collider and checks if player is grounded.
      float radius = _playerCollider.radius * 0.9f;
      Vector3 pos = transform.position + Vector3.up*(radius*0.9f);
      bool isGrounded = Physics.CheckSphere(pos, radius, groundLayer);
      
      //Jump function.
      if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
      {
         rbPlayer.AddForce(Vector3.up * 300f, ForceMode.Force);
      }
      
      rbPlayer.MovePosition(rbPlayer.position + movement * (speed * Time.deltaTime));
      
   }
}
