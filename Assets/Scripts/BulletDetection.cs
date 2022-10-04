using System.Collections;
using UnityEngine;

public class BulletDetection : MonoBehaviour
{ 
    public Shooting owner;
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
            if (owner != collision.gameObject.transform.GetChild(0).GetChild(2).GetComponent<Shooting>())
            {
                collision.gameObject.GetComponent<PlayerStats>().TakeDamage();
                Destroy(gameObject);
            }
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
