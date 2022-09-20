using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void Update()
    {
        OutOfBounds();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    private void OutOfBounds()
    {
        if (gameObject.transform.position.y <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
