using System.Collections;
using UnityEngine;

public class BulletDetection : MonoBehaviour
{
    private void Update()
    {
        OutOfBounds();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            StartCoroutine(WaitBeforeDestroy());
        }
        else if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(20);
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

    IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
