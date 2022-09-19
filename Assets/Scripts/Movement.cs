using UnityEngine;

public class Movement : MonoBehaviour
{
   public float speed = 2f;
   private Rigidbody rbPlayer;
   private CapsuleCollider playerCollider;
   public LayerMask groundLayer;

   private Vector2 turn;
   private float sensitivity = 2f;

   private void Start()
   {
      playerCollider = GetComponent<CapsuleCollider>();
      rbPlayer = GetComponent<Rigidbody>();
      Cursor.lockState = CursorLockMode.Locked;
   }

   private void LateUpdate()
   {
      //Rotate left and right with the mouse.
      turn.x += Input.GetAxis("Mouse X") * sensitivity;
      transform.localRotation = Quaternion.Euler(0, turn.x, 0);

      float uD = Input.GetAxisRaw("Horizontal");
      float lR = Input.GetAxisRaw("Vertical");
      Vector3 movement = transform.forward * lR + transform.right * uD;
      
      //Make a radius based on the player collider and checks if player is grounded.
      float radius = playerCollider.radius * 0.9f;
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
