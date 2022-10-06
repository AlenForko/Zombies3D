using System.Collections;
using Unity.VisualScripting;
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
   private bool isGrounded;

   private AudioSource _audioSource;
   [SerializeField]private AudioClip _audioClip;

   private void Start()
   {
      _audioSource = GetComponent<AudioSource>();
      _playerCollider = GetComponent<CapsuleCollider>();
      rbPlayer = GetComponent<Rigidbody>();
      Cursor.lockState = CursorLockMode.Locked;
   }

   private void Update()
   {
      isMoving = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
      animator.SetBool("isMoving", isMoving);
      if (isMoving && !PauseMenu.gameIsPaused)
      {
         if (!_audioSource.isPlaying)
         {
            _audioSource.PlayOneShot(_audioClip);
         }
      }
      else
      {
         _audioSource.Stop();
      }
   }

   private void LateUpdate()
   {
      if (!PauseMenu.gameIsPaused)
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
         isGrounded = Physics.CheckSphere(pos, radius, groundLayer);
         animator.SetBool("isGrounded", isGrounded);
      
         //Jump function.
         if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
         {
            rbPlayer.AddForce(Vector3.up * 300f, ForceMode.Force);
            animator.Play("Z_jump_A_start");
         }
      
         //rbPlayer.MovePosition(rbPlayer.position + movement * (speed * Time.deltaTime));
         float y = rbPlayer.velocity.y;
         Vector3 movVector = new Vector3(movement.x * speed, y,movement.z * speed);
         rbPlayer.velocity = movVector;
      }
   }
}
