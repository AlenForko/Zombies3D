using UI;
using UnityEngine;

namespace Player
{
   public class Movement : MonoBehaviour
   {
      private const float _speed = 5f;
      private Rigidbody _rbPlayer;
      private CapsuleCollider _playerCollider;
      public LayerMask groundLayer;

      private Vector2 _turn;
      private float _sensitivity = 2f;

      public Animator animator;
      private bool _isMoving;
      private bool _isGrounded;

      private AudioSource _audioSource;
      [SerializeField]private AudioClip _audioClip;

      private void Start()
      {
         _audioSource = GetComponent<AudioSource>();
         _playerCollider = GetComponent<CapsuleCollider>();
         _rbPlayer = GetComponent<Rigidbody>();
         Cursor.lockState = CursorLockMode.Locked;
      }

      private void Update()
      {
         _isMoving = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
         animator.SetBool("isMoving", _isMoving);
         if (_isMoving && !PauseMenu.GameIsPaused && _isGrounded)
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
         if (!PauseMenu.GameIsPaused)
         {
            //Rotate left and right with the mouse.
            _turn.x += Input.GetAxis("Mouse X") * _sensitivity;
            transform.localRotation = Quaternion.Euler(0, _turn.x, 0);

            float uD = Input.GetAxisRaw("Horizontal");
            float lR = Input.GetAxisRaw("Vertical");
            Vector3 movement = transform.forward * lR + transform.right * uD;
      
      
            //Make a radius based on the player collider and checks if player is grounded.
            float radius = _playerCollider.radius * 0.9f;
            Vector3 pos = transform.position + Vector3.up*(radius*0.9f);
            _isGrounded = Physics.CheckSphere(pos, radius, groundLayer);
            animator.SetBool("isGrounded", _isGrounded);
      
            //Jump function.
            if(Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
               _rbPlayer.AddForce(Vector3.up * 300f, ForceMode.Force);
               animator.Play("Z_jump_A_start");
            }
         
            float y = _rbPlayer.velocity.y;
            Vector3 movVector = new Vector3(movement.x * _speed, y,movement.z * _speed);
            _rbPlayer.velocity = movVector;
         }
      }
   }
}
