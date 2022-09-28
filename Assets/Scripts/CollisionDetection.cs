using System.Collections;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void Update()
    {
        OutOfBounds();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Player"))
        {
            StartCoroutine(WaitBeforeDestroy());
        }
    }

    private void OutOfBounds()
    {
        if (gameObject.transform.position.y <= 0f)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
